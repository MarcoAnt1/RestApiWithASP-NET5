using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASP_NET5.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public User ValidadeCredentials(UserVO user)
        {
            var password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == password);
        }

        public User ValidadeCredentials(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public bool RevokeToken(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user is null)
                return false;

            user.RefreshToken = null;

            _context.SaveChanges();

            return true;
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id == user.Id))
                return null;

            var result = _context.Users.SingleOrDefault(x => x.Id == user.Id);
            try
            {
                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}

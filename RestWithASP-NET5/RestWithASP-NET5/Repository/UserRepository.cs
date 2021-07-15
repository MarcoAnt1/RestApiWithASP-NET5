using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        private static string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}

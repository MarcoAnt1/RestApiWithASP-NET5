using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using RestWithASP_NET5.Repository.Generic;
using System;
using System.Linq;

namespace RestWithASP_NET5.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySqlContext context) : base (context) { }

        public Person Disable(long id)
        {
            if (!_context.People.Any(p => p.Id == id))
                return null;

            var user = _context.People.SingleOrDefault(p => p.Id == id);
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return user;
        }
    }
}

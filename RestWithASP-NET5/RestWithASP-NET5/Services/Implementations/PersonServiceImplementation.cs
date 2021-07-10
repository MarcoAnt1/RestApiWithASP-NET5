using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASP_NET5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            person.Id = 1;

            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Marco",
                LastName = "Souza",
                Address = "Vila Sonia - São Paulo - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        } 
        
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = 1,
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName {i}",
                Address = $"Some Address {i}",
                Gender = GetGender(i)
            };
        }

        private static string GetGender(int i)
        {
            if (i % 2 == 0)
                return "Male";
            else
                return "Famale";
        }
    }
}

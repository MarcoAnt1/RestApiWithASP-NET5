using RestWithASP_NET5.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASP_NET5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            person.Id = IncrementAndGet();

            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> people = new();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }

            return people;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
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
                Id = IncrementAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName {i}",
                Address = $"Some Address {i}",
                Gender = GetGender(i)
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
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

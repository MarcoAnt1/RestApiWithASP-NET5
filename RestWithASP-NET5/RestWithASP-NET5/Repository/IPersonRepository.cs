using RestWithASP_NET5.Model;

namespace RestWithASP_NET5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}

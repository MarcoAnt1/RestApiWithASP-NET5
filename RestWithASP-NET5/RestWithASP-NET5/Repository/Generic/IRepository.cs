using RestWithASP_NET5.Model.Base;
using System.Collections.Generic;

namespace RestWithASP_NET5.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        T Update(T item);

        void Delete(long id);

        T FindById(long id);

        List<T> FindAll();

        bool Exists(long id);
    }
}

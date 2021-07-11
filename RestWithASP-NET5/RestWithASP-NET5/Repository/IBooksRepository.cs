using RestWithASP_NET5.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5.Repository
{
    public interface IBooksRepository
    {
        Books Create(Books books);

        Books Update(Books books);

        void Delete(long id);

        Books FindById(long id);

        List<Books> FindAll();

        bool Exists(long id);
    }
}

using RestWithASP_NET5.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books Books);

        Books Update(Books person);

        void Delete(long id);

        Books FindById(long id);

        List<Books> FindAll();
    }
}

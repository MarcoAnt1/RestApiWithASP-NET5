using RestWithASP_NET5.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IBooksBusiness
    {
        Book Create(Book Books);

        Book Update(Book person);

        void Delete(long id);

        Book FindById(long id);

        List<Book> FindAll();
    }
}

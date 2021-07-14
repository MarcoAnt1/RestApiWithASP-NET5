using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);

        BookVO Update(BookVO book);

        void Delete(long id);

        BookVO FindById(long id);

        List<BookVO> FindAll();
    }
}

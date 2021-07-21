using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Hypermedia.Utils;
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

        PagedSearchVO<BookVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}

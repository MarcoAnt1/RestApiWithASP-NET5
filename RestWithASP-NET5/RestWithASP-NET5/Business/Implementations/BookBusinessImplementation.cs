using RestWithASP_NET5.Data.Converter.Implementations;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Hypermedia.Utils;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = pageSize < 1 ? 10 : pageSize;
            var offset = pageSize > 0 ? (page - 1) * size : 0;

            string query = @"SELECT * FROM books b WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title))
            {
                query += $" AND b.title LIKE '%{title}%' ";
            }

            query += $" ORDER BY b.title {sort} LIMIT {size} OFFSET {offset}";

            string countQuery = @"SELECT * FROM books b WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title))
            {
                countQuery += $" AND b.title LIKE '%{title}%' ";
            }

            var books = _repository.FindWithPagedSearch(query);
            var totalResults = 0;
            if (books.Any())
            {
                totalResults = _repository.GetCount(countQuery);
            }

            return new PagedSearchVO<BookVO>
            {
                CurrentPage = page,
                List = _converter.Parse(books),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            Book personEntity = _converter.Parse(book);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public BookVO Update(BookVO book)
        {
            Book personEntity = _converter.Parse(book);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

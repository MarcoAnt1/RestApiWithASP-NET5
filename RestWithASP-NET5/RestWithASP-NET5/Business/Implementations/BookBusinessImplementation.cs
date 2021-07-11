using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Implementations
{
    public class BookBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book books)
        {
            return _repository.Create(books);
        }

        public Book Update(Book books)
        {
            return _repository.Update(books);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Repository.Implementations
{
    public class BooksRepositoryImplementation : IBooksRepository
    {
        private readonly MySqlContext _context;

        public BooksRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public List<Books> FindAll()
        {
            return _context.Books.ToList();
        }

        public Books FindById(long id)
        {
            return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
        }

        public Books Create(Books books)
        {
            try
            {
                _context.Add(books);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return books;
        }

        public Books Update(Books books)
        {
            if (!Exists(books.Id))
                return null;

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(books.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(books);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return books;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}

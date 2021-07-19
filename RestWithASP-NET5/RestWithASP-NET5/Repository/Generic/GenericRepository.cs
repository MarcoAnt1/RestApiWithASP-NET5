using Microsoft.EntityFrameworkCore;
using RestWithASP_NET5.Model.Base;
using RestWithASP_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MySqlContext _context;

        private readonly DbSet<T> dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(x => x.Id == id);
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        public T Update(T item)
        {
            if (!Exists(item.Id))
                return null;

            var result = dataSet.SingleOrDefault(x => x.Id == item.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataSet.Any(x => x.Id == id);
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataSet.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";

            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }

            return int.Parse(result);
        }
    }
}

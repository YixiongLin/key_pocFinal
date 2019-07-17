using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace key_pocFinal.Repository
{
    public class genericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public genericRepo(DbContext db)
        {
            _dbContext = db;
        }
        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public T get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> getAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> cond)
        {
            return _dbContext.Set<T>().Where(cond);
        }
    }
}
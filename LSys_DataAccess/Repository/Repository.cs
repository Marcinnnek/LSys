using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository
{
    public class Repository<T,  N> : IRepository<T, N> where T : class
    {
        protected readonly LSysDbContext _dbContext;

        public Repository(LSysDbContext _DbContext)
        {
            _dbContext = _DbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public T GetById(N id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public List<T> GetRange(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

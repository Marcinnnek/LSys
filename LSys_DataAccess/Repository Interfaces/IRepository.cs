using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository_Interfaces
{
    public interface IRepository<TResult, TInput, N> where TResult : class where TInput : class // TInput - Domain // TResult - DTO
    {
        TInput GetById(N id);
        List<TInput> GetRange(Expression<Func<TResult, bool>> predicate);
        void Add(TInput entity);
        void Update(TInput entity);
        void Remove(TInput entity);
    }
}

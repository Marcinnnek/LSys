﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository_Interfaces
{
    public interface IRepository<T, N> where T : class
    {
        T GetById(N id);
        List<T> GetRange(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}

﻿using AutoMapper;
using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain;
using LSys_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository
{
    public class Repository<TResult, TInput, TId> : IRepository<TResult, TInput, TId> where TResult : class where TInput : class // TInput - DTO // TResult - Domain
    {
        protected readonly LSysDbContext _dbContext;
        protected readonly IMapper _mapper;

        public Repository(LSysDbContext _DbContext, IMapper mapper)
        {
            _dbContext = _DbContext;
            _mapper = mapper;
        }

        public object Add(TInput entity)
        {
            TResult result = _mapper.Map<TResult>(entity);
            _dbContext.Set<TResult>().Add(result);

            return GetIdFromObj(result);
        }

        public TInput GetById(TId id)
        {
            return _mapper.Map<TInput>(_dbContext.Set<TResult>().Find(id));
        }

        //public IEnumerable<TInput> GetRange(Expression<Func<TResult, bool>> predicate, Expression<Func<TResult,bool>> orderBy)
        //{
        //    var dbEntities = _dbContext.Set<TResult>().Where(predicate).OrderBy(orderBy);
        //    var result = _mapper.Map<IQueryable<TResult>, IEnumerable<TInput>>(dbEntities);
        //    return result;
        //}
        public IEnumerable<TInput> GetRange(Expression<Func<TResult, bool>> predicate)
        {
            var dbEntities = _dbContext.Set<TResult>().OrderBy(predicate);
            var result = _mapper.Map<IQueryable<TResult>, IEnumerable<TInput>>(dbEntities);
            return result;
        }

        public IEnumerable<TInput> GetAll() 
        {
            var dbEntities = _dbContext.Set<TResult>();
            var result = _mapper.Map<IEnumerable<TResult>, IEnumerable<TInput>>(dbEntities);
            return result;
        }

        public void Remove(TInput entity)
        {
            TResult result = _mapper.Map<TResult>(entity);
            _dbContext.Set<TResult>().Remove(result);
        }

        public void Update(TInput entity)
        {
            throw new NotImplementedException();
        }

        private object? GetIdFromObj(object obj)
        {
            Type resultType = obj.GetType();
            PropertyInfo ?propInfo = resultType.GetProperty(nameof(EntityBase<TId>.Id));
            object? propValue;
            if (propInfo != null)
            {
                return propValue = propInfo.GetValue(obj, null);
            }
            else
            {
                return null;
            }
        }

    }
}

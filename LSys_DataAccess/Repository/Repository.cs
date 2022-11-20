using AutoMapper;
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

            //Type resultType = result.GetType();
            //PropertyInfo propInfo = resultType.GetProperty(nameof(EntityBase<TId>.Id));
            //object? propValue;
            //if (propInfo != null)
            //{
            //    return propValue = propInfo.GetValue(result, null);
            //}
            //else
            //{
            //    return null;
            //}
            return GetIdFromObj(result);
        }

        public TInput GetById(TId id)
        {
            return _mapper.Map<TInput>(_dbContext.Set<TResult>().Find(id));
        }

        public List<TInput> GetRange(Expression<Func<TResult, bool>> predicate)
        {
            throw new NotImplementedException();
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

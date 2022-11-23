using LSys_Domain;
using LSys_Domain.Entities;
using LSys_DataAccess.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSys_DataAccess.Repository;
using LSys_DataAccess.DTOs;
using System.Linq.Expressions;
using AutoMapper;

namespace LSys_DataAccess.Repository
{
    public class UserRepository : Repository<AppUser, UserDTO, Guid>, IUserRepository
    {
        public UserRepository(LSysDbContext _DbContext, IMapper mapper) : base(_DbContext, mapper)
        {
        }

        public bool CheckUserExist(string email)
        {
            var result = _dbContext.Users.Where(u => u.Email == email).AsNoTracking();
            return result.Count() > 0 ? true : false;
        }

        //public UserDTO GetUserWithRoles(string email)
        //{
        //    var entity = _dbContext.Users.Include(u => u.Roles).FirstOrDefault(e => e.Email == email);
        //    var result =_mapper.Map<UserDTO>(entity);
        //    return result;
        //}
        //public async Task<TResult> Get<TResult>(Guid userId, Expression<Func<LSys_Domain.Entities.User, TResult>> selector) // tu fajne
        //{
        //    var result = await _dbContext.Users
        //        .Where(x => x.Id == userId)
        //        .Select(selector)
        //        .SingleOrDefaultAsync();
        //    return result;
        //}

    }
}

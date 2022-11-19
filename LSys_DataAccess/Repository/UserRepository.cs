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

namespace LSys_DataAccess.Repository
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(LSysDbContext _DbContext) : base(_DbContext)
        {
        }

        public bool CheckUserExist(string phrase)
        {
            var result = _dbContext.Users.Where(u => u.Email == phrase).AsNoTracking();
            return result.Count() > 0 ? true : false;
        }

        // Dodać metody rozszerzające w razie potrzeby
    }
}

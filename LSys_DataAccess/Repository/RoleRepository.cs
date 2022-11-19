using LSys_Domain.Entities;
using LSys_Domain;
using LSys_DataAccess.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LSys_DataAccess.Repository
{
    public class RoleRepository : Repository<Role, Guid>, IRoleRepository
    {

        public RoleRepository(LSysDbContext _DbContext) : base(_DbContext)
        {
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = _dbContext.Roles.AsNoTracking(); ;
            return roles;
        }

        // Dodać metody rozszerzające w razie potrzeby

    }
}

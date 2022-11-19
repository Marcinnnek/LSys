using LSys_Domain;
using LSys_Domain.Entities;
using LSys_DataAccess.Repository_Interfaces;

namespace LSys_DataAccess.Repository
{
    public class UserRoleRepository : Repository<UserRoleList, Guid>, IUserRoleRepository
    {
        public UserRoleRepository(LSysDbContext _DbContext) : base(_DbContext)
        {

        }

        // Dodać metody rozszerzające w razie potrzeby
    }
}

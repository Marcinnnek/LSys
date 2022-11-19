using LSys_DataAccess.Repository;
using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain;

namespace LSys_DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LSysDbContext _dbContext;
        public UnitOfWork(LSysDbContext _DbContext)
        {
            _dbContext = _DbContext;
            Users = new UserRepository(_dbContext);
            Roles = new RoleRepository(_dbContext);
            UsersRoles = new UserRoleRepository(_dbContext);
        }
        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IUserRoleRepository UsersRoles { get; private set; }

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

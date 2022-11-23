using AutoMapper;
using LSys_DataAccess.Repository;
using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain;
using LSys_Domain.Entities;

namespace LSys_DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LSysDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(LSysDbContext _DbContext, IMapper mapper)
        {
            _dbContext = _DbContext;
            _mapper = mapper;
            Users = new UserRepository(_dbContext, _mapper);
            Roles = new RoleRepository(_dbContext, _mapper);
            UsersRoles = new UserRoleRepository(_dbContext, _mapper);
            Devices = new DeviceRepository(_dbContext, _mapper);
            WiFiCredentials = new WiFiCredentialsRepository(_dbContext, _mapper);
        }
        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IUserRoleRepository UsersRoles { get; private set; }
        public IDeviceRepository Devices{ get; private set; }
        public IWiFiCredentialsRepository WiFiCredentials { get; private set; }

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

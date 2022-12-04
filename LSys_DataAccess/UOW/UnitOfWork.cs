using AutoMapper;
using LSys_DataAccess.Repository;
using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain;
using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace LSys_DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LSysDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UnitOfWork(LSysDbContext _DbContext, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _dbContext = _DbContext;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            Users = new UserRepository(_dbContext, _mapper, _userManager, _signInManager);
            Roles = new RoleRepository(_dbContext, _mapper);
            Devices = new DeviceRepository(_dbContext, _mapper);
            WiFiCredentials = new WiFiCredentialsRepository(_dbContext, _mapper);
            MQTTCredentials = new MQTTCredentialsRepository(_dbContext, _mapper);
        }
        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        //public IUserRoleRepository UsersRoles { get; private set; }
        public IDeviceRepository Devices{ get; private set; }
        public IWiFiCredentialsRepository WiFiCredentials { get; private set; }
        public IMQTTCredentialsRepository MQTTCredentials { get; private set; }

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

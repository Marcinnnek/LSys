using LSys_DataAccess.Repository_Interfaces;

namespace LSys_DataAccess.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IUserRoleRepository UsersRoles { get; }
        IDeviceRepository Devices { get; }
        IWiFiCredentialsRepository WiFiCredentials{ get; }
        Task<int> Complete();
    }
}

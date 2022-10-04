using LSys_DB.Entities;
using Microsoft.EntityFrameworkCore;
// psql pass: BazaMarcinka
namespace LSys_DB
{
    public class LSysDbContext : DbContext
    {
        public LSysDbContext(DbContextOptions<LSysDbContext> options) : base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<WiFiCredentials> WiFiCredentials { get; set; }
        public DbSet<MQTTCredentials> MQTTCredentials { get; set; }
        public DbSet<LuxSensor> LuxSensors { get; set; }
        public DbSet<LuxSensorData> LuxSensorDatas { get; set; }
        public DbSet<EnvironmentSensor> EnvironmentSensors { get; set; }
        public DbSet<EnivronmentSensorData> EnvironmentSensorDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(U =>
            {
                U.HasOne(R => R.Role).WithMany().HasForeignKey(R => R.RoleId); //Użytkownik ma jedną rolę, jedna rola może być przypisana do wielu użtkowników.
            });

            modelBuilder.Entity<Device>(D => 
            {
                D.HasOne(U => U.User).WithMany().HasForeignKey(U => U.UserId); //Jedno urządzenie ma wielu użytkowników
            });
        }
    }
}
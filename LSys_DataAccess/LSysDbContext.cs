using LSys_Domain.Entities;
using LSys_Domain.Entities.Dimmers;
using LSys_Domain.Entities.Schedulers;
using LSys_Domain.Entities.Sensors;
using Microsoft.EntityFrameworkCore;

// psql pass: BazaMarcinka
namespace LSys_Domain
{
    public class LSysDbContext : DbContext
    {
        public LSysDbContext(DbContextOptions<LSysDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<WiFiCredentials> WiFiCredentials { get; set; }
        public DbSet<MQTTCredentials> MQTTCredentials { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Readings> Readings { get; set; }
        public DbSet<SensorSettings> SensorSettings { get; set; }
        public DbSet<Dimmer> Dimmers { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().Property(R => R.Name).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<User>(EB =>
            {
                // User - Role, Many to Many
                EB.HasMany(U => U.Roles)
                .WithMany(R => R.Users) // prosta konfiguracja bez widocznej tabeli pośredniej
                .UsingEntity<UserRoleList>( // dodatkowa konfiguracja z tabelą pośrednią tak aby mozna było dodać dodatkowe dane w tej tablei jeśli zajdzie potrzeba
                    U => U.HasOne(UR => UR.Role)
                    .WithMany()
                    .HasForeignKey(UR => UR.RoleId),

                    U => U.HasOne(UR => UR.User)
                    .WithMany()
                    .HasForeignKey(UR => UR.UserId),

                    UR =>
                    {
                        UR.HasKey(x => new { x.UserId, x.RoleId }); // klucze główne dla tabeli pośredniej
                    });

                EB.Property(U => U.Email).HasMaxLength(25).IsRequired();
                EB.HasIndex(U => new { U.Email, U.UserName }).IsUnique(true);
                EB.Property(U => U.UserName).HasMaxLength(20).IsRequired();
                EB.Property(U => U.Password).IsRequired();
                EB.Property(U => U.Description).HasMaxLength(250);
            });

            // User - Device, Many to Many
            modelBuilder.Entity<Device>(EB =>
            {
                EB.HasMany(D => D.Users)
                .WithMany(U => U.Devices) // prosta konfiguracja bez widocznej tabeli pośredniej
                .UsingEntity<UserDeviceList>( // dodatkowa konfiguracja z tabelą pośrednią tak aby mozna było dodać dodatkowe dane w tej tablei jeśli zajdzie potrzeba
                    D => D.HasOne(UD => UD.User)
                    .WithMany()
                    .HasForeignKey(UD => UD.UserId),

                    D => D.HasOne(UD => UD.Device)
                    .WithMany()
                    .HasForeignKey(UD => UD.DeviceId),

                    UD =>
                    {
                        UD.HasKey(x => new { x.UserId, x.DeviceId }); // klucze główne dla tabeli pośredniej
                    });

                EB.Property(D => D.Name).HasMaxLength(20);
                EB.Property(D => D.Description).HasMaxLength(250);
                EB.Property(D => D.Location).HasMaxLength(20);
                EB.Property(D => D.Group).HasMaxLength(10);

            });

            // Device - WiFiCredentials, One to Many - Jedna konfiguracja wifi może mieć przypisanych wiele urządzeń
            modelBuilder.Entity<WiFiCredentials>(EB =>
            {
                EB.HasMany(WiFiC => WiFiC.Devices) // Wiązanie od strony tabeli WiFi
                .WithOne(D => D.WiFiCredentials)
                .HasForeignKey(D => D.WiFiCredentialsId);

                //EB.HasOne(D => D.WiFiCredentials) // Wiązanaie od strony tabeli Device
                //.WithMany(WiFiC => WiFiC.Devices)
                //.HasForeignKey(D=>D.WiFiCredentialsId);

                EB.Property(WiFiC => WiFiC.SSID).HasMaxLength(30);
                EB.Property(WiFiC => WiFiC.DeviceIP).HasMaxLength(15);
                EB.HasIndex(WiFiC => WiFiC.DeviceIP).IsUnique(true);
                EB.Property(WiFiC => WiFiC.GateWay).HasMaxLength(15);
                EB.Property(WiFiC => WiFiC.ResetPassword).HasMaxLength(20);

            });

            // Device - MQTTCredentials, One to One - Jedna konfiguracja MQTT może mieć przypisanych jedno urządzenie
            modelBuilder.Entity<MQTTCredentials>(EB =>
            {
                EB.HasOne(MQTTC => MQTTC.Device) // Wiązanie od strony MQTT
                .WithOne(D => D.MQTTCredentials)
                .HasForeignKey<Device>(D => D.MQTTCredentialsId);

                //EB.HasOne(D => D.MQTTCredentials) // Wiązanie od strony Device
                //.WithOne(MQTTC => MQTTC.Device)
                //.HasForeignKey<MQTTCredentials>(MQTTC => MQTTC.MQTTId);

                EB.Property(MQTTC => MQTTC.ServerIp).HasMaxLength(15);
                EB.Property(MQTTC => MQTTC.Port).HasMaxLength(5);
                EB.Property(MQTTC => MQTTC.MQTTId).HasMaxLength(36);
                EB.Property(MQTTC => MQTTC.Login).HasMaxLength(20);



            });

            modelBuilder.Entity<Sensor>(EB =>
            {
                EB.HasOne(S => S.Device)
                .WithMany(D => D.Sensors)
                .HasForeignKey(S => S.DeviceId)
                .HasPrincipalKey(S => S.Id); // może być ale nie musi, EF sam wnioskuje jeśli jest kolumna Id

                EB.Property(S => S.Name).HasMaxLength(20);
                EB.Property(S => S.Units).HasMaxLength(20).IsRequired();
            });

            modelBuilder.Entity<Readings>(EB =>
            {
                EB.HasOne(R => R.Sensor)
                .WithMany(S => S.Readings)
                .HasForeignKey(R => R.SensorId);
            });

            modelBuilder.Entity<SensorSettings>(EB =>
            {
                EB.HasOne(SS => SS.Sensor)
                .WithOne(S => S.SensorSettings)
                .HasForeignKey<Sensor>(S => S.SensorSettingsId);
            });

            modelBuilder.Entity<Dimmer>(EB =>
            {
                EB.HasOne(Dim => Dim.Device)
                .WithMany(D => D.Dimmers)
                .HasForeignKey(Dim => Dim.DeviceId);
            });

            modelBuilder.Entity<Scheduler>(EB =>
            {
                EB.HasMany(S => S.Dimmers)
                .WithMany(D => D.Schedulers)
                .UsingEntity<DimmerSchedulerList>(
                     S => S.HasOne(DS => DS.Dimmer)
                    .WithMany()
                    .HasForeignKey(DS => DS.DimmerId),

                    S => S.HasOne(DS => DS.Scheduler)
                    .WithMany()
                    .HasForeignKey(DS => DS.SchedulerId),

                    DS =>
                    {
                        DS.HasKey(x => new { x.SchedulerId, x.DimmerId });
                    });

                EB.Property(Sch => Sch.Name).HasMaxLength(50);
                EB.Property(Sch => Sch.Description).HasMaxLength(250);


            });
        }
    }
}
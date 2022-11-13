﻿// <auto-generated />
using System;
using LSys_DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LSys_DB.Migrations
{
    [DbContext(typeof(LSysDbContext))]
    partial class LSysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LSys_DB.Entities.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MQTTCredentialsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WiFiCredentialsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MQTTCredentialsId")
                        .IsUnique();

                    b.HasIndex("WiFiCredentialsId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("LSys_DB.Entities.Dimmers.DimmerSchedulerList", b =>
                {
                    b.Property<int>("SchedulerId")
                        .HasColumnType("int");

                    b.Property<int>("DimmerId")
                        .HasColumnType("int");

                    b.HasKey("SchedulerId", "DimmerId");

                    b.HasIndex("DimmerId");

                    b.ToTable("DimmerSchedulerList");
                });

            modelBuilder.Entity("LSys_DB.Entities.MQTTCredentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MQTTId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Port")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MQTTCredentials");
                });

            modelBuilder.Entity("LSys_DB.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LSys_DB.Entities.Schedulers.Dimmer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Dimmers");
                });

            modelBuilder.Entity("LSys_DB.Entities.Schedulers.Scheduler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FrequencyInterval")
                        .HasColumnType("int");

                    b.Property<int>("FrequencyType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SetValue")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeOfDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAd")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedulers");
                });

            modelBuilder.Entity("LSys_DB.Entities.Sensors.Readings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("MeasureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("Readings");
                });

            modelBuilder.Entity("LSys_DB.Entities.Sensors.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SensorSettingsId")
                        .HasColumnType("int");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("SensorSettingsId")
                        .IsUnique();

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("LSys_DB.Entities.Sensors.SensorSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("MeasurementPeriod")
                        .HasColumnType("real");

                    b.Property<float>("Offset")
                        .HasColumnType("real");

                    b.Property<DateTime>("SettingsUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SensorSettings");
                });

            modelBuilder.Entity("LSys_DB.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LSys_DB.Entities.UserDeviceList", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "DeviceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("UserDeviceList");
                });

            modelBuilder.Entity("LSys_DB.Entities.UserRoleList", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoleList");
                });

            modelBuilder.Entity("LSys_DB.Entities.WiFiCredentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DeviceIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GateWay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WiFiCredentials");
                });

            modelBuilder.Entity("LSys_DB.Entities.Device", b =>
                {
                    b.HasOne("LSys_DB.Entities.MQTTCredentials", "MQTTCredentials")
                        .WithOne("Device")
                        .HasForeignKey("LSys_DB.Entities.Device", "MQTTCredentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSys_DB.Entities.WiFiCredentials", "WiFiCredentials")
                        .WithMany("Devices")
                        .HasForeignKey("WiFiCredentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MQTTCredentials");

                    b.Navigation("WiFiCredentials");
                });

            modelBuilder.Entity("LSys_DB.Entities.Dimmers.DimmerSchedulerList", b =>
                {
                    b.HasOne("LSys_DB.Entities.Schedulers.Dimmer", "Dimmer")
                        .WithMany()
                        .HasForeignKey("DimmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSys_DB.Entities.Schedulers.Scheduler", "Scheduler")
                        .WithMany()
                        .HasForeignKey("SchedulerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dimmer");

                    b.Navigation("Scheduler");
                });

            modelBuilder.Entity("LSys_DB.Entities.Schedulers.Dimmer", b =>
                {
                    b.HasOne("LSys_DB.Entities.Device", "Device")
                        .WithMany("Dimmers")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("LSys_DB.Entities.Sensors.Readings", b =>
                {
                    b.HasOne("LSys_DB.Entities.Sensors.Sensor", "Sensor")
                        .WithMany("Readings")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("LSys_DB.Entities.Sensors.Sensor", b =>
                {
                    b.HasOne("LSys_DB.Entities.Device", "Device")
                        .WithMany("Sensors")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSys_DB.Entities.Sensors.SensorSettings", "SensorSettings")
                        .WithOne("Sensor")
                        .HasForeignKey("LSys_DB.Entities.Sensors.Sensor", "SensorSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("SensorSettings");
                });

            modelBuilder.Entity("LSys_DB.Entities.UserDeviceList", b =>
                {
                    b.HasOne("LSys_DB.Entities.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSys_DB.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LSys_DB.Entities.UserRoleList", b =>
                {
                    b.HasOne("LSys_DB.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSys_DB.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LSys_DB.Entities.Device", b =>
                {
                    b.Navigation("Dimmers");

                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("LSys_DB.Entities.MQTTCredentials", b =>
                {
                    b.Navigation("Device")
                        .IsRequired();
                });

            modelBuilder.Entity("LSys_DB.Entities.Sensors.Sensor", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("LSys_DB.Entities.Sensors.SensorSettings", b =>
                {
                    b.Navigation("Sensor")
                        .IsRequired();
                });

            modelBuilder.Entity("LSys_DB.Entities.WiFiCredentials", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}

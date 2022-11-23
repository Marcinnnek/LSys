using LSys_DataAccess.DTOs;
using LSys_DataAccess.Repository;
using LSys_DataAccess.Repository_Interfaces;
using LSys_DataAccess.UOW;
using LSys_Domain;
using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess
{
    public static class DataAccessEFServices
    {
        public static IServiceCollection AddDataAccessEFServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LSysDbContext>(options =>
             {
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
             });

            services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<LSysDbContext>();
            //services.AddScoped<IPasswordHasher<UserDTO>, PasswordHasher<UserDTO>>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

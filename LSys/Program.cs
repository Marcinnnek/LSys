using LSys.Services;
using LSys_DataAccess;
using LSys_DataAccess.Repository;
using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LSys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddScoped<LSysDbSeeder>();
            builder.Services.AddHostedService<MQTTSubscribeService>();
            builder.Services.AddHostedService<MQTTPublishService>();
            builder.Services.AddScoped<IUserService, UserService>();
            //builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            //builder.Services.AddDbContext<LSysDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            builder.Services.AddDataAccessEFServices(builder.Configuration); // Dodanie serwisów z warstwy DataAccess

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                var scope = app.Services.CreateScope();
                var seeder = scope.ServiceProvider.GetRequiredService<LSysDbSeeder>();
                seeder.Seed();
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                var scope = app.Services.CreateScope();
                var seeder = scope.ServiceProvider.GetRequiredService<LSysDbSeeder>();
                seeder.Seed();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LSys API"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
using FluentValidation;
using LSys.Middleware;
using LSys.Services;
using LSys.View_Models;
using LSys.View_Models.Validators;
using LSys_DataAccess;
using LSys_DataAccess.Repository;
using LSys_Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace LSys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var authenticationSettings = new AuthenticationSettings();

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddAuthorization();
            builder.Services.AddControllersWithViews();

            // Fluent validation
            builder.Services.AddFluentValidationAutoValidation(); 
            //builder.Services.AddFluentValidationClientsideAdapters(); // w tym momencie zbêdne
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();



            //builder.Services.AddHostedService<MQTTSubscribeService>();
            //builder.Services.AddHostedService<MQTTPublishService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();

            builder.Services.AddScoped<LSysDbSeeder>();

            //builder.Services.AddScoped<IValidator<RegisterUserVM>, RegisterUserVMValidator>();
            builder.Services.AddDataAccessEFServices(builder.Configuration); // Dodanie serwisów z warstwy DataAccess
            builder.Services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 0;
            });

            //builder.Services.AddScoped<ErrorHandlingMiddleware>();

            builder.Services.AddHttpContextAccessor(); // potem do UserContextService

            builder.Services.AddSwaggerGen();

            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            var app = builder.Build();
            app.UseResponseCaching();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
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
            //app.UseMiddleware<ErrorHandlingMiddleware>();



            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LSys API"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
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
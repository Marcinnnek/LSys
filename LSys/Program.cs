using LSys.Middleware;
using LSys.Services;
using LSys_DataAccess;
using LSys_DataAccess.Repository;
using LSys_Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LSys
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // var authenticationSettings = new AuthenticationSettings();

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddAuthorization();

            // Add services to the container.
            //builder.Services.AddSingleton(authenticationSettings);
            //builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            //{
            //    cfg.RequireHttpsMetadata = false;
            //    cfg.SaveToken = true;
            //    cfg.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidIssuer = authenticationSettings.JwtIssuer, //wydawca tokenu
            //        ValidAudience = authenticationSettings.JwtIssuer, // jakie podmioty mog¹ u¿ywaæ tokenu (ta sama wartoœæ bo generujemy token w obrêbie aplikacji)
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
            //    };
            //});

            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddScoped<LSysDbSeeder>();
            builder.Services.AddHostedService<MQTTSubscribeService>();
            builder.Services.AddHostedService<MQTTPublishService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddDataAccessEFServices(builder.Configuration); // Dodanie serwisów z warstwy DataAccess

            builder.Services.AddScoped<ErrorHandlingMiddleware>();

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
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication(); // wymuszenie autentykacji JWT
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
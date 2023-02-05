using LSys_Domain;
using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LSys
{
    public class LSysDbSeeder
    {
        private readonly LSysDbContext _dbContext;

        public LSysDbSeeder(LSysDbContext _DbContext)
        {
            _dbContext = _DbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name="Spectator",
                    NormalizedName= "Spectator".ToUpper(),
                },
                new IdentityRole()
                {
                    Name="User",
                    NormalizedName= "User".ToUpper(),
                },
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName= "Admin".ToUpper(),
                },

            };

            return roles;
        }



    }
}

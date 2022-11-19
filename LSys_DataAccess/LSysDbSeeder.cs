using LSys_Domain;
using LSys_Domain.Entities;

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

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name="User"
                },
                new Role()
                {
                    Name="Spectator"
                },

            };

            return roles;
        }
    }
}

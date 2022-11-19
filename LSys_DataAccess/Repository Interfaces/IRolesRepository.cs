using LSys_Domain.Entities;
using LSys_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository_Interfaces
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        public IEnumerable<Role> GetRoles();
    }
}


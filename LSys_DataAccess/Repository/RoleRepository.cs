using LSys_Domain.Entities;
using LSys_Domain;
using LSys_DataAccess.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LSys_DataAccess.DTOs;
using Microsoft.AspNetCore.Identity;

namespace LSys_DataAccess.Repository
{
    public class RoleRepository : Repository<IdentityRole, RoleDTO, Guid>, IRoleRepository
    {
        public RoleRepository(LSysDbContext _DbContext, IMapper mapper) : base(_DbContext, mapper)
        {

        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            var roles = _mapper.Map<IEnumerable<IdentityRole>, IEnumerable<RoleDTO>>(_dbContext.Roles.AsNoTracking().AsEnumerable());
            return roles;
        }

        // Dodać metody rozszerzające w razie potrzeby

    }
}

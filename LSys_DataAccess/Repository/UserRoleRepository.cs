using LSys_Domain;
using LSys_Domain.Entities;
using LSys_DataAccess.Repository_Interfaces;
using AutoMapper;
using LSys_DataAccess.DTOs;

namespace LSys_DataAccess.Repository
{
    public class UserRoleRepository : Repository<UserRoleList, UserRoleListDTO, Guid>, IUserRoleRepository
    {
        public UserRoleRepository(LSysDbContext _DbContext, IMapper mapper) : base(_DbContext, mapper)
        {

        }

        // Dodać metody rozszerzające w razie potrzeby
    }
}



﻿using LSys_Domain.Entities;
using LSys_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSys_DataAccess.DTOs;
using Microsoft.AspNetCore.Identity;

namespace LSys_DataAccess.Repository_Interfaces
{
    public interface IRoleRepository : IRepository<IdentityRole, RoleDTO, Guid>
    {
        public IEnumerable<RoleDTO> GetRoles();
    }
}


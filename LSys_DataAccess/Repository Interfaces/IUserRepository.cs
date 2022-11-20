﻿using LSys_DataAccess.DTOs;
using LSys_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LSys_DataAccess.Repository_Interfaces
{
    public interface IUserRepository : IRepository<User, UserDTO, Guid>
    {
        public bool CheckUserExist(string phrase);
        //public User NewUser(UserDTO userDTO);
    }
}

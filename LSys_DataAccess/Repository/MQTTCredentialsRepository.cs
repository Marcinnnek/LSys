using AutoMapper;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.Repository;
using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain.Entities;
using LSys_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository
{
    public class MQTTCredentialsRepository : Repository<MQTTCredentials, MQTTCredentialsDTO, Guid>, IMQTTCredentialsRepository
    {
        public MQTTCredentialsRepository(LSysDbContext _DbContext, IMapper mapper) : base(_DbContext, mapper)
        {
        }

    }
}
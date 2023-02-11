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
using Microsoft.EntityFrameworkCore;

namespace LSys_DataAccess.Repository
{
    public class MQTTCredentialsRepository : Repository<MQTTCredentials, MQTTCredentialsDTO, Guid>, IMQTTCredentialsRepository
    {
        public MQTTCredentialsRepository(LSysDbContext _DbContext, IMapper mapper) : base(_DbContext, mapper)
        {
        }

        public MQTTCredentialsDTO GetMQTTCredentiaslsByLogin(string login)
        {
            var dbEntity = _dbContext.MQTTCredentials.FirstOrDefault(x => x.Login == login);
            var mqttCDTO = _mapper.Map<MQTTCredentialsDTO>(dbEntity);
               
            return mqttCDTO;
        }

    }
}
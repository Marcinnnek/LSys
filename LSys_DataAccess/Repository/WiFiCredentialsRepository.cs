using AutoMapper;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain;
using LSys_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository
{
    public class WiFiCredentialsRepository : Repository<WiFiCredentials, WiFiCredentialsDTO, Guid>, IWiFiCredentialsRepository
    {
        public WiFiCredentialsRepository(LSysDbContext _DbContext, IMapper mapper) : base(_DbContext, mapper)
        {
        }

    }
}

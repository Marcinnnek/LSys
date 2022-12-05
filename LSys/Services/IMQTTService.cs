using LSys.View_Models;
using LSys_DataAccess.DTOs;

namespace LSys.Services
{
    public interface IMQTTService
    {
        Task<DbResult<MQTTCredentialsDTO>> AddMQTTServer(AddMQTTVM mqttVM, Guid deviceId);
    }
}

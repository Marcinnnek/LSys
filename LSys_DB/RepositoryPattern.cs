using LSys_DB.Entities;
using LSys_DB.Entities.Sensors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB
{
    // Testy
    //Cześć, pytanie z tych głupszych i prosił bym o potwierdzenie moich wywodów.Mam klasę abstrakcyjną EnityBase która jest generyczna Id - Guid lub int, chciałbym z niej dziedziczyć w dwóch klasach w której jedno id było by Guid a w drugiej int. Czy przy takiej konstrukcji jak poniżej będzie to działać we wzorcu repozytorium? Czy jestem zmuszony do wyboru tylko jednego typu danych dla Id? Pozdrawiam.

    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
    }

    public interface IGenericRepository<T, N> where T : class
    {
        T GetById(N id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class GenericRepository<T, N> : IGenericRepository<T, N> where T : class
    {
        protected readonly LSysDbContext _context;
        public GenericRepository(LSysDbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(N id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }


    public interface IDeviceRepository : IGenericRepository<Device, Guid>
    {
        // tu wrzucić dodatkowe metody dla danej encji
        public IEnumerable<Device> GetAllDevices();
    }
    public interface ISensorRepository : IGenericRepository<Sensor, int>
    {
        // tu wrzucić dodatkowe metody dla danej encji
    }
    public class DeviceRepository : GenericRepository<Device, Guid>, IDeviceRepository
    {
        public DeviceRepository(LSysDbContext context) : base(context)
        {

        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _context.Devices.ToList();
        }
    }
}

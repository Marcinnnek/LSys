using LSys_DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB
{
    // Testy
    

    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
    }


    public class Order : EntityBase<int>
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
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
    }
    public interface IUserRepository : IGenericRepository<User, int>
    {
        // tu wrzucić dodatkowe metody dla danej encji
    }
    public class DeviceRepository : GenericRepository<Device, Guid>, IDeviceRepository
    {
        public DeviceRepository(LSysDbContext context) : base(context)
        {

        }

        public IEnumerable<Device> GetDeviceById(Guid id)
        {
            return (IEnumerable<Device>)_context.Devices.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_Domain.Entities
{
    public interface IEntityBase<T>
    {
        public T Id { get; set; }
    }
}

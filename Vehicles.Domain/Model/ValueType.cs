using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Domain.Model
{
    public abstract class ValueType
    {
        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}

using System.Collections.Generic;
using Vehicles.Domain.Exceptions;

namespace Vehicles.Domain.Model
{
    public class Wheel : ValueType
    {
        private readonly Size MIN_SIZE = new Size(10);

        /// <summary>
        /// Create a new wheel instance. The size must be greater or equal than 10 "
        /// </summary>
        public Wheel(Size size)
        {
            if (size < MIN_SIZE)
                throw new InvalidWheelSizeException(MIN_SIZE);

            Size = size;
        }

        /// <summary>
        /// The quantity of size
        /// </summary>
        public Size Size{ get; }

        public override bool Equals(object obj)
        {
            return obj is Wheel wheel &&
                   EqualityComparer<Size>.Default.Equals(Size, wheel.Size);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Size);
        }
    }
}

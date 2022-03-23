using System.Collections.Generic;
using Vehicles.Domain.Exceptions;

namespace Vehicles.Domain.Model
{
    public class Wheels : ValueType
    {
        private readonly IReadOnlyList<Wheel> wheels;

        /// <summary>
        /// Create a set of wheels. All wheels have the same size.
        /// The number of wheels must be greater than zero and even.
        /// </summary>
        public Wheels(int numberOfWheels, Size sizeOfWheels)
        {
            if (numberOfWheels <= 0 ||
                numberOfWheels % 2 != 0)
                throw new InvalidNumberOfWheelsException();

            NumberOfWheels = numberOfWheels;
            
            var wheels = new List<Wheel>();
            for (int i = 0; i < NumberOfWheels; i++)
            {
                wheels.Add(new Wheel(sizeOfWheels));
            }
            this.wheels = wheels;
        }

        /// <summary>
        /// Number of wheels
        /// </summary>
        public int NumberOfWheels { get; }

        /// <summary>
        /// Get each wheel
        /// </summary>
        public Wheel this[int index]
        {
            get
            {
                return wheels[index];
            }           
        }

        public override bool Equals(object obj)
        {
            return obj is Wheels wheels &&
                   NumberOfWheels == wheels.NumberOfWheels;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(NumberOfWheels);
        }
    }
}

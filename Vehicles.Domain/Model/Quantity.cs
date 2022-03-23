using System;
using Vehicles.Domain.Exceptions;

namespace Vehicles.Domain.Model
{
    public abstract class Quantity : ValueType
    {
        /// <summary>
        /// Create a new Quantity instance. 
        /// </summary>
        protected Quantity(int value, string unit, int minValue, int maxValue, string name)
        {
            if (value < minValue || value > maxValue)
                throw new InvalidQuantityException(name, minValue, maxValue, unit);

            Value = value;
            Unit = unit;         
        }

        /// <summary>
        /// Amount of the quantity
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Unit of the quantity
        /// </summary>
        public string Unit { get; }

       public override bool Equals(object obj)
        {
            return obj is Quantity quantity &&
                   Value == quantity.Value &&
                   Unit == quantity.Unit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Unit);
        }

        public static bool operator >(Quantity quantity1, Quantity quantity2)
        {
            return (quantity1.Value > quantity2.Value);
        }

        public static bool operator <(Quantity quantity1, Quantity quantity2)
        {
            return (quantity1.Value < quantity2.Value);
        }

        /// <summary>
        /// String representation of the quantity
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}

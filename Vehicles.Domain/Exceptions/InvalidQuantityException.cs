using System;

namespace Vehicles.Domain.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        /// <summary>
        /// The parameters compose the exception message. If the minValue is int.MinValue, there is no lower limit;
        /// If the maxValue is int.MaxValue, there is no upper limit; If both minValue and maxValue are different from
        /// int.MinValue and int.MaxValue, respectively, there are lower and upper limit.
        /// </summary>
        public InvalidQuantityException(string name, int minValue, int maxValue, string unit)
            : base(GetMessage(name, minValue, maxValue, unit))
        {
        }

        private static string GetMessage(string name, int minValue, int maxValue, string unit)
        {
            if (minValue == int.MinValue)
                return $"The {name} must be less or equal than {maxValue} {unit}";
            if (maxValue == int.MaxValue)
                return $"The {name} must be greater or equal than {minValue} {unit}";
            return $"The {name} must be greater or equal {minValue} {unit} and less or equal than {maxValue} {unit}";
        }
    }
}

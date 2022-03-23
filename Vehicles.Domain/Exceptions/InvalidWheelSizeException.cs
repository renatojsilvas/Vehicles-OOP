using System;
using Vehicles.Domain.Model;

namespace Vehicles.Domain.Exceptions
{
    public class InvalidWheelSizeException : Exception
    {
        public InvalidWheelSizeException(Size minSize)
            : base($"The wheel size must be greater or equal than {minSize}")
        {
        }
    }
}

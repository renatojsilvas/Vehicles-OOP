using System;

namespace Vehicles.Domain.Exceptions
{
    public class InvalidNumberOfWheelsException : Exception
    {
        public InvalidNumberOfWheelsException()
            : base("The number of wheels must be greater than zero and even")
        {
        }
    }
}

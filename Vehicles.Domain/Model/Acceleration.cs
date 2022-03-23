namespace Vehicles.Domain.Model
{
    public class Acceleration : Quantity
    {
        private static readonly int MIN_ACCELERATION = 18000;
        private static readonly int MAX_ACCELERATION = 72000;
        private const string DEFAULT_UNIT = "km/h²";

        /// <summary>
        /// Create a new acceleration instance. The default unit is km/h² 
        /// The acceleration must be greater or equal than 300 km/h² and less or equal than 1200 km/h²
        /// </summary>
        public Acceleration(int value)
            : base(value, DEFAULT_UNIT, MIN_ACCELERATION, MAX_ACCELERATION, nameof(Acceleration).ToLower())
        {
        }

        public static int MinValue => MIN_ACCELERATION;
    }
}

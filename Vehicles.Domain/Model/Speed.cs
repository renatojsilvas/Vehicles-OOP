namespace Vehicles.Domain.Model
{
    public class Speed : Quantity
    {
        private static int MIN_SPEED  = 0;
        private static int MAX_SPEED = 300;

        private const string DEFAULT_UNIT = "km/h";

        /// <summary>
        /// Create a new speed instance. The default unit is km/h 
        /// The speed must be greater or equal than 0 km/h and less or equal than 300 km/h
        /// </summary>
        public Speed(int value)
            : base(value, DEFAULT_UNIT, MIN_SPEED, MAX_SPEED, nameof(Speed).ToLower())
        {
        }
    }
}

namespace Vehicles.Domain.Model
{
    public class Size : Quantity
    {
        private static readonly int MIN_SIZE = 1;
        private static readonly int MAX_SIZE = int.MaxValue;
        private const string DEFAULT_UNIT = "\"";

        /// <summary>
        /// Create a new size instance. The default unit is " (Inches) 
        /// The size must be greater than 0 "
        /// </summary>
        public Size(int value)
            : base(value, DEFAULT_UNIT, MIN_SIZE, MAX_SIZE, nameof(Size).ToLower())
        {
        }
    }
}

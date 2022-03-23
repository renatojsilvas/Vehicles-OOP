using Vehicles.Domain.Model;

namespace Vehicles.Domain.Services
{
    public class AccelerationCalculatorService
    {
        public Acceleration Calculate(Acceleration acceleration, Weight weight)
        {
            int value;

            if (weight == Weight.Medium)
                value = (int)(acceleration.Value * .75);
            else if (weight == Weight.High)
                value = (int)(acceleration.Value * .5);
            else
                value = acceleration.Value;

            if (value < Acceleration.MinValue)
                value = Acceleration.MinValue;

            return new Acceleration(value);
        }
    }
}

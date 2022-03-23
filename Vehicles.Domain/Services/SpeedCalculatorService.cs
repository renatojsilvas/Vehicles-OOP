using Vehicles.Domain.Model;

namespace Vehicles.Domain.Services
{
    public class SpeedCalculatorService
    {
        public Speed Calculate(Speed speed, Weight weight)
        {
            if (weight == Weight.Medium)
                return new Speed((int)(speed.Value * .75));
            else if (weight == Weight.High)
                return new Speed((int)(speed.Value * .5));
            else
                return speed;
        }
    }
}

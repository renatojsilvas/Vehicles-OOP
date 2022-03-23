using System.Drawing;

namespace Vehicles.Domain.Model
{
    public class NormalCar : Car
    {
        public NormalCar(Color color)
            : base(color, Weight.Medium, Power.Medium, new Wheels(4, new Size(13)))
        {
        }
    }
}

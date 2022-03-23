using System.Drawing;

namespace Vehicles.Domain.Model
{
    public class SmallMotorcycle : Motorcycle
    {
        public SmallMotorcycle(Color color)
            : base(color, Weight.Low, Power.Low, new Wheels(2, new Size(20)))
        {
        }
    }
}

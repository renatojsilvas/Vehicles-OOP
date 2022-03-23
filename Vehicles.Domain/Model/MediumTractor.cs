using System.Drawing;

namespace Vehicles.Domain.Model
{
    public class MediumTractor : Tractor
    {
        public MediumTractor(Color color)
            : base(color, Weight.High, Power.High, new Wheels(4, new Size(40)))
        {
        }
    }
}

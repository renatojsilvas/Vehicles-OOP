using System.Drawing;
using Vehicles.Domain.Interfaces;

namespace Vehicles.Domain.Model
{
    public class Car : Vehicle, ICar
    {
        protected Car(Color color, Weight weight, Power power, Wheels wheels) 
            : base(color, weight, power, wheels)
        {
        }
    }
}

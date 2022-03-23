using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Domain.Interfaces;

namespace Vehicles.Domain.Model
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        protected Motorcycle(Color color, Weight weight, Power power, Wheels wheels) 
            : base(color, weight, power, wheels)
        {
            MotorcyclePosition = MotorcyclePosition.Normal;
        }

        public MotorcyclePosition MotorcyclePosition { get; private set; }

        public void DoAWheelie()
        {
            MotorcyclePosition = MotorcyclePosition.Up;
        }

        public void UndoAWheelie()
        {
            MotorcyclePosition = MotorcyclePosition.Normal;
        }
    }
}

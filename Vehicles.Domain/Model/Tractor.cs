using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Domain.Interfaces;

namespace Vehicles.Domain.Model
{
    public class Tractor : Vehicle, ITractor
    {
        protected Tractor(Color color, Weight weight, Power power, Wheels wheels) 
            : base(color, weight, power, wheels)
        {
            ShovelPosition = ShovelPosition.Low;
        }

        public ShovelPosition ShovelPosition { get; set; }

        public void MoveShovelDown()
        {
            ShovelPosition = ShovelPosition.Low;
        }

        public void MoveShovelUp()
        {
            ShovelPosition = ShovelPosition.High;
        }
    }
}

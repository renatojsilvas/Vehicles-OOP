using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Domain.Model;

namespace Vehicles.Domain.Services
{
    public class SpeedIncrementCalculatorService
    {
        public float Calculate(Acceleration acceleration, TimeSpan delta)
        {
            return acceleration.Value / 3600.0f * (float)delta.TotalSeconds;
        }
    }
}

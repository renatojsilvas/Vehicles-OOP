﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Domain.Interfaces
{
    public interface ISimulation
    {
        void SetStartTime(DateTime startTime);
        void SampleTime(DateTime currentTime);
    }
}

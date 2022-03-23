using System.Collections.Generic;

namespace Vehicles.Domain.Model
{
    public class Engine : ValueType
    {
        /// <summary>
        /// Create new engine instance. It is possible
        /// to create a loww, medium or high power engine
        /// </summary>
        public Engine(Power power)
        {
            if (power == Power.Low)
            {
                Capacity = EngineCapacity.Low;
                Noise = Noise.Low;
                Acceleration = new Acceleration(18000);
                TopSpeed = new Speed(100);
            }

            if (power == Power.Medium)
            {
                Capacity = EngineCapacity.Medium;
                Noise = Noise.Medium;
                Acceleration = new Acceleration(30000);
                TopSpeed = new Speed(250);
            }

            if (power == Power.High)
            {
                Capacity = EngineCapacity.High;
                Noise = Noise.High;
                Acceleration = new Acceleration(72000);
                TopSpeed = new Speed(300);
            }
        }

        /// <summary>
        /// Engine capacity
        /// </summary>
        public EngineCapacity Capacity { get; }

        /// <summary>
        /// Noise from the engine
        /// </summary>
        public Noise Noise { get; }

        /// <summary>
        /// Acceleration from the given power
        /// </summary>
        public Acceleration Acceleration { get; }

        /// <summary>
        ///  Top speed from the engine
        /// </summary>
        public Speed TopSpeed { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Engine engine &&
                   Capacity == engine.Capacity &&
                   Noise == engine.Noise &&
                   EqualityComparer<Acceleration>.Default.Equals(Acceleration, engine.Acceleration) &&
                   EqualityComparer<Speed>.Default.Equals(TopSpeed, engine.TopSpeed);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Capacity, Noise, Acceleration, TopSpeed);
        }
    }
}

using System;
using System.Drawing;
using Vehicles.Domain.Interfaces;
using Vehicles.Domain.Services;

namespace Vehicles.Domain.Model
{
    public abstract class Vehicle : IVehicle, ISimulation
    {
        private SpeedCalculatorService speedCalculatorService = new SpeedCalculatorService();
        private AccelerationCalculatorService accelerationCalculatorService = new AccelerationCalculatorService();
        private SpeedIncrementCalculatorService speedIncrementCalculator = new SpeedIncrementCalculatorService();
        private float currentSpeed;
        private AccelerationLevel currentAcceleration;

        protected Vehicle(Color color, Weight weight, Power power, Wheels wheels)
        {
            Color = color;
            Weight = weight;
            Engine = new Engine(power);
            TopSpeed = speedCalculatorService.Calculate(Engine.TopSpeed, Weight);
            Acceleration = accelerationCalculatorService.Calculate(Engine.Acceleration, Weight);
            Noise = Engine.Noise;
            Wheels = wheels;

            currentSpeed = 0;
            lastTime = DateTime.Now;
            currentAcceleration = AccelerationLevel.No; 
        }

        public Wheels Wheels { get; }
        public Color Color { get; }
        public Weight Weight { get; }
        public Engine Engine { get; }
        public Speed TopSpeed { get; }
        public Acceleration Acceleration { get; }
        public Noise Noise { get; }

        public void Accelerate(AccelerationLevel level)
        {
            currentAcceleration = level;
        }

        public void Stop()
        {
            currentSpeed = 0;
            currentAcceleration = AccelerationLevel.No;
        }

        public Speed CurrentSpeed => new Speed((int)currentSpeed);

        private DateTime lastTime;
        public void SetStartTime(DateTime startTime)
        {
            lastTime = startTime;
        }

        public void SampleTime(DateTime currentTime)
        {
            if (currentAcceleration == AccelerationLevel.No)
                return;

            var effectiveAcceleration = Acceleration.Value * (currentAcceleration == AccelerationLevel.Full ? 1f : 0.5f);
            if (effectiveAcceleration < Acceleration.MinValue)
                effectiveAcceleration = Acceleration.MinValue;

            TimeSpan delta = currentTime - lastTime;
            var increment = speedIncrementCalculator.Calculate(new Acceleration((int)effectiveAcceleration), delta);
            currentSpeed += increment;

            if (currentSpeed > TopSpeed.Value)
            {
                currentSpeed = TopSpeed.Value;
            }
        }        
    }
}

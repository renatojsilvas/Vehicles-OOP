using FluentAssertions;
using System;
using System.Drawing;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Vehicles
{
    public class CarTests
    {
        [Fact]
        public void Car_ShouldCreateANewCarInstance()
        {
            // Arrange
            NormalCar car;

            // Act
            car = new NormalCar(Color.Black);

            // Assert
            car.Weight.Should().Be(Weight.Medium);
            car.Color.Should().Be(Color.Black);
            car.Engine.Should().Be(new Engine(Power.Medium));
            car.Acceleration.Should().Be(new Acceleration(22500));
            car.TopSpeed.Should().Be(new Speed(187));
            car.Noise.Should().Be(Noise.Medium);
            car.Wheels.Should().Be(new Wheels(4, new Domain.Model.Size(13)));
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByFullAcceleration()
        {
            // Arrange
            NormalCar car;
            var startTime = DateTime.Now;

            // Act & Assert
            car = new NormalCar(Color.Black);
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
            car.Accelerate(AccelerationLevel.Full);
            car.SetStartTime(startTime);
            car.SampleTime(startTime.AddSeconds(10));
            car.CurrentSpeed.ToString().Should().Be("62 km/h");
            car.SampleTime(startTime.AddSeconds(60));
            car.CurrentSpeed.ToString().Should().Be("187 km/h");
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByHalfAcceleration()
        {
            // Arrange
            NormalCar car;
            var startTime = DateTime.Now;

            // Act & Assert
            car = new NormalCar(Color.Black);
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
            car.Accelerate(AccelerationLevel.Half);
            car.SetStartTime(startTime);
            car.SampleTime(startTime.AddSeconds(10));
            car.CurrentSpeed.ToString().Should().Be("50 km/h");
            car.SampleTime(startTime.AddSeconds(600));
            car.CurrentSpeed.ToString().Should().Be("187 km/h");
        }

        [Fact]
        public void Accelerate_ShouldNotIncreaseTheSpeedByNoAcceleration()
        {
            // Arrange
            NormalCar car;
            var startTime = DateTime.Now;

            // Act & Assert
            car = new NormalCar(Color.Black);
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
            car.Accelerate(AccelerationLevel.No);
            car.SetStartTime(startTime);
            car.SampleTime(startTime.AddSeconds(10));
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
            car.SampleTime(startTime.AddSeconds(600));
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByAccelerationUntilTopSpeed()
        {
            // Arrange
            NormalCar car;
            var startTime = DateTime.Now;

            // Act & Assert
            car = new NormalCar(Color.Black);
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
            car.Accelerate(AccelerationLevel.Full);
            car.SetStartTime(startTime);
            car.SampleTime(startTime.AddSeconds(10));
            car.CurrentSpeed.ToString().Should().Be("62 km/h");
        }

        [Fact]
        public void Stop_ShouldStopTheCar()
        {
            // Arrange
            NormalCar car;
            var startTime = DateTime.Now;

            // Act & Assert
            car = new NormalCar(Color.Black);
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
            car.Accelerate(AccelerationLevel.Full);
            car.SetStartTime(startTime);
            car.SampleTime(startTime.AddSeconds(10));
            car.CurrentSpeed.ToString().Should().Be("62 km/h");
            car.Stop();
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
            car.SampleTime(startTime.AddSeconds(10));
            car.CurrentSpeed.ToString().Should().Be("0 km/h");
        }
    }
}

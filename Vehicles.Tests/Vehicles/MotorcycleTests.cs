using FluentAssertions;
using System;
using System.Drawing;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Vehicles
{
    public class MotorcycleTests
    {
        [Fact]
        public void Motorcycle_ShouldCreateANewCarInstance()
        {
            // Arrange
            SmallMotorcycle motorcycle;

            // Act
            motorcycle = new SmallMotorcycle(Color.Red);

            // Assert
            motorcycle.Weight.Should().Be(Weight.Low);
            motorcycle.Color.Should().Be(Color.Red);
            motorcycle.Engine.Should().Be(new Engine(Power.Low));
            motorcycle.Acceleration.Should().Be(new Acceleration(18000));
            motorcycle.TopSpeed.Should().Be(new Speed(100));
            motorcycle.Wheels.Should().Be(new Wheels(2, new Domain.Model.Size(20)));
            motorcycle.Noise.Should().Be(Noise.Low);
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByFullAcceleration()
        {
            // Arrange
            SmallMotorcycle tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new SmallMotorcycle(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Full);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("50 km/h");
            tractor.SampleTime(startTime.AddSeconds(60));
            tractor.CurrentSpeed.ToString().Should().Be("100 km/h");
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByHalfAcceleration()
        {
            // Arrange
            SmallMotorcycle tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new SmallMotorcycle(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Half);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("50 km/h");
            tractor.SampleTime(startTime.AddSeconds(600));
            tractor.CurrentSpeed.ToString().Should().Be("100 km/h");
        }

        [Fact]
        public void Accelerate_ShouldNotIncreaseTheSpeedByNoAcceleration()
        {
            // Arrange
            SmallMotorcycle tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new SmallMotorcycle(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.No);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.SampleTime(startTime.AddSeconds(600));
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByAccelerationUntilTopSpeed()
        {
            // Arrange
            SmallMotorcycle tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new SmallMotorcycle(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Full);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("50 km/h");
        }

        [Fact]
        public void Stop_ShouldStopThetractor()
        {
            // Arrange
            SmallMotorcycle tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new SmallMotorcycle(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Full);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("50 km/h");
            tractor.Stop();
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
        }

        [Fact]
        public void MoveShovelUp_ShouldMoveMotorcyclePositionToUp()
        {
            // Arrange
            SmallMotorcycle tractor;

            // Act & Assert
            tractor = new SmallMotorcycle(Color.Black);
            tractor.MotorcyclePosition.Should().Be(MotorcyclePosition.Normal);
            tractor.DoAWheelie();
            tractor.MotorcyclePosition.Should().Be(MotorcyclePosition.Up);
        }

        [Fact]
        public void MoveShovelUp_ShouldMoveMotorcyclePositionToDown()
        {
            // Arrange
            SmallMotorcycle tractor;

            // Act & Assert
            tractor = new SmallMotorcycle(Color.Black);
            tractor.MotorcyclePosition.Should().Be(MotorcyclePosition.Normal);
            tractor.DoAWheelie();
            tractor.MotorcyclePosition.Should().Be(MotorcyclePosition.Up);
            tractor.UndoAWheelie();
            tractor.MotorcyclePosition.Should().Be(MotorcyclePosition.Normal);
        }
    }
}

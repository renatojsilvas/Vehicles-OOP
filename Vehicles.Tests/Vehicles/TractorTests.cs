using FluentAssertions;
using System;
using System.Drawing;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Vehicles
{
    public class TractorTests
    {
        [Fact]
        public void Tractor_ShouldCreateANewtractorInstance()
        {
            // Arrange
            MediumTractor tractor;

            // Act
            tractor = new MediumTractor(Color.Yellow);

            // Assert
            tractor.Weight.Should().Be(Weight.High);
            tractor.Color.Should().Be(Color.Yellow);
            tractor.Engine.Should().Be(new Engine(Power.High));
            tractor.Acceleration.Should().Be(new Acceleration(36000));
            tractor.TopSpeed.Should().Be(new Speed(150));
            tractor.Wheels.Should().Be(new Wheels(4, new Domain.Model.Size(40)));
            tractor.Noise.Should().Be(Noise.High);
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByFullAcceleration()
        {
            // Arrange
            MediumTractor tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new MediumTractor(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Full);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("100 km/h");
            tractor.SampleTime(startTime.AddSeconds(60));
            tractor.CurrentSpeed.ToString().Should().Be("150 km/h");
        }

        [Fact]
        public void Accelerate_ShouldIncreaseTheSpeedByHalfAcceleration()
        {
            // Arrange
            MediumTractor tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new MediumTractor(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Half);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("50 km/h");
            tractor.SampleTime(startTime.AddSeconds(600));
            tractor.CurrentSpeed.ToString().Should().Be("150 km/h");
        }

        [Fact]
        public void Accelerate_ShouldNotIncreaseTheSpeedByNoAcceleration()
        {
            // Arrange
            MediumTractor tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new MediumTractor(Color.Black);
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
            MediumTractor tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new MediumTractor(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Full);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("100 km/h");
        }

        [Fact]
        public void Stop_ShouldStopThetractor()
        {
            // Arrange
            MediumTractor tractor;
            var startTime = DateTime.Now;

            // Act & Assert
            tractor = new MediumTractor(Color.Black);
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.Accelerate(AccelerationLevel.Full);
            tractor.SetStartTime(startTime);
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("100 km/h");
            tractor.Stop();
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
            tractor.SampleTime(startTime.AddSeconds(10));
            tractor.CurrentSpeed.ToString().Should().Be("0 km/h");
        }

        [Fact]
        public void MoveShovelUp_ShouldMoveShovelPositionToUp()
        {
            // Arrange
            MediumTractor tractor;

            // Act & Assert
            tractor = new MediumTractor(Color.Black);
            tractor.ShovelPosition.Should().Be(ShovelPosition.Low);
            tractor.MoveShovelUp();
            tractor.ShovelPosition.Should().Be(ShovelPosition.High);
        }

        [Fact]
        public void MoveShovelUp_ShouldMoveShovelPositionToDown()
        {
            // Arrange
            MediumTractor tractor;

            // Act & Assert
            tractor = new MediumTractor(Color.Black);
            tractor.ShovelPosition.Should().Be(ShovelPosition.Low);
            tractor.MoveShovelUp();
            tractor.ShovelPosition.Should().Be(ShovelPosition.High);
            tractor.MoveShovelDown();
            tractor.ShovelPosition.Should().Be(ShovelPosition.Low);
        }
    }
}

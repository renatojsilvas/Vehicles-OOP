using FluentAssertions;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Models
{
    public class EngineTests
    {
        [Fact]
        public void Engine_ShouldCreateANewInstance_WhenLowPowerIsProvided()
        {
            // Arrange
            Engine sut;

            // Act
            sut = new Engine(Power.Low);

            // Assert
            sut.Capacity.Should().Be(EngineCapacity.Low);
            sut.Noise.Should().Be(Noise.Low);
            sut.Acceleration.Should().Be(new Acceleration(18000));
            sut.TopSpeed.Should().Be(new Speed(100));
        }

        [Fact]
        public void Engine_ShouldCreateANewInstance_WhenMediumPowerIsProvided()
        {
            // Arrange
            Engine sut;

            // Act
            sut = new Engine(Power.Medium);

            // Assert
            sut.Capacity.Should().Be(EngineCapacity.Medium);
            sut.Noise.Should().Be(Noise.Medium);
            sut.Acceleration.Should().Be(new Acceleration(30000));
            sut.TopSpeed.Should().Be(new Speed(250));
        }

        [Fact]
        public void Engine_ShouldCreateANewInstance_WhenHighPowerIsProvided()
        {
            // Arrange
            Engine sut;

            // Act
            sut = new Engine(Power.High);

            // Assert
            sut.Capacity.Should().Be(EngineCapacity.High);
            sut.Noise.Should().Be(Noise.High);
            sut.Acceleration.Should().Be(new Acceleration(72000));
            sut.TopSpeed.Should().Be(new Speed(300));
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenTheyAreEqual()
        {
            // Arrange
            Engine engine1 = new Engine(Power.High); 
            Engine engine2 = new Engine(Power.High); 

            // Act
            var result = engine1.Equals(engine2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void GetHashCode_ShouldReturnTrue_WhenTheyAreEqual()
        {
            // Arrange
            Engine engine1 = new Engine(Power.High);
            Engine engine2 = new Engine(Power.High);

            // Act
            var result = engine1.GetHashCode().Equals(engine2.GetHashCode());

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenTheyAreNotEqual()
        {
            // Arrange
            Engine engine1 = new Engine(Power.High);
            Engine engine2 = new Engine(Power.Medium);

            // Act
            var result = engine1.Equals(engine2);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenTheInstancesAreDifferent()
        {
            // Arrange
            Engine engine1 = new Engine(Power.High);
            object instance = new object();

            // Act
            var result = engine1.Equals(instance);

            // Assert
            result.Should().BeFalse();
        }
    }
}

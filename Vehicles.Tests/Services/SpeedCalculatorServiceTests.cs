using FluentAssertions;
using Vehicles.Domain.Model;
using Vehicles.Domain.Services;
using Xunit;

namespace Vehicles.Tests.Services
{
    public class SpeedCalculatorServiceTests
    {
        [Fact]
        public void Calculate_ShouldReturnTheMaxSpeed_When_WeightIsLow()
        {
            // Arrange 
            SpeedCalculatorService service = new SpeedCalculatorService();

            // Act
            var result = service.Calculate(new Speed(100), Weight.Low);

            // Assert
            result.Should().Be(new Speed(100));
        }

        [Fact]
        public void Calculate_ShouldReturnTheMaxSpeedMinus25Percent_When_WeightIsMedium()
        {
            // Arrange 
            SpeedCalculatorService service = new SpeedCalculatorService();

            // Act
            var result = service.Calculate(new Speed(100), Weight.Medium);

            // Assert
            result.Should().Be(new Speed(75));
        }

        [Fact]
        public void Calculate_ShouldReturnTheMaxSpeedMinus50Percent_When_WeightIsHigh()
        {
            // Arrange 
            SpeedCalculatorService service = new SpeedCalculatorService();

            // Act
            var result = service.Calculate(new Speed(100), Weight.High);

            // Assert
            result.Should().Be(new Speed(50));
        }
    }
}

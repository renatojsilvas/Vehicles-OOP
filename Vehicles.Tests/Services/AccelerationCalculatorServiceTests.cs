using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Domain.Model;
using Vehicles.Domain.Services;
using Xunit;

namespace Vehicles.Tests.Services
{
    public class AccelerationCalculatorServiceTests
    {
        [Fact]
        public void Calculate_ShouldReturnTheMaxSpeed_When_WeightIsLow()
        {
            // Arrange 
            AccelerationCalculatorService service = new AccelerationCalculatorService();

            // Act
            var result = service.Calculate(new Acceleration(50000), Weight.Low);

            // Assert
            result.Should().Be(new Acceleration(50000));
        }

        [Fact]
        public void Calculate_ShouldReturnTheMaxSpeedMinus25Percent_When_WeightIsMedium()
        {
            // Arrange 
            AccelerationCalculatorService service = new AccelerationCalculatorService();

            // Act
            var result = service.Calculate(new Acceleration(50000), Weight.Medium);

            // Assert
            result.Should().Be(new Acceleration(37500));
        }

        [Fact]
        public void Calculate_ShouldReturnTheMaxSpeedMinus50Percent_When_WeightIsHigh()
        {
            // Arrange 
            AccelerationCalculatorService service = new AccelerationCalculatorService();

            // Act
            var result = service.Calculate(new Acceleration(50000), Weight.High);

            // Assert
            result.Should().Be(new Acceleration(25000));
        }

        [Fact]
        public void Calculate_ShouldReturnThe300_When_WeightIsHighAndAccelerationIs500()
        {
            // Arrange 
            AccelerationCalculatorService service = new AccelerationCalculatorService();

            // Act
            var result = service.Calculate(new Acceleration(18000), Weight.High);

            // Assert
            result.Should().Be(new Acceleration(18000));
        }
    }
}

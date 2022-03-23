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
    public class SpeedIncrementCalculatorServiceTests
    {
        [Fact]
        public void Calculate_ShouldCalculateTheIncrementInVelocity_When_AccelerationAndDeltaIsProvided()
        {
            // Arrange
            SpeedIncrementCalculatorService sut = new SpeedIncrementCalculatorService();

            // Act
            var result = sut.Calculate(new Acceleration(18000), TimeSpan.FromSeconds(20));

            // Assert
            result.Should().Be(100);
        }
    }
}

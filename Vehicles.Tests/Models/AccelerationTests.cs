using FluentAssertions;
using System;
using Vehicles.Domain.Exceptions;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Models
{
    public class AccelerationTests
    {
        [Fact]
        public void Acceleration_ShouldBeCreatedSuccesfully_When_ItIs300kmPerSquareHour()
        {
            // Arrange
            Acceleration sut;

            // Act
            sut = new Acceleration(18000);

            // Assert
            sut.Value.Should().Be(18000);
        }

        [Fact]
        public void Acceleration_ShouldBeCreatedSuccesfully_When_ItIs1200kmPerSquareHour()
        {
            // Arrange
            Acceleration sut;

            // Act
            sut = new Acceleration(72000);

            // Assert
            sut.Value.Should().Be(72000);
        }

        [Fact]
        public void Unit_ShouldBekmPerSquareHourByDefault_When_AnyAccelerationIsCreated()
        {
            // Arrange
            Acceleration sut;

            // Act
            sut = new Acceleration(18000);

            // Assert
            sut.Unit.Should().Be("km/h²");
        }

        [Fact]
        public void Speed_ShouldBeThrownAnInvalidSpeedException_When_ItIsLessThan300kmPerSquareHour()
        {
            // Arrange

            // Act 
            Action sut = () => new Acceleration(17999);

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidQuantityException>()
                               .WithMessage("The acceleration must be greater or equal 18000 km/h² and less or equal than 72000 km/h²");
        }

        [Fact]
        public void Speed_ShouldBeThrownAnInvalidSpeedException_When_ItIsGreaterThan1200kmPerSquareHour()
        {
            // Arrange

            // Act 
            Action sut = () => new Acceleration(72001);

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidQuantityException>()
                               .WithMessage("The acceleration must be greater or equal 18000 km/h² and less or equal than 72000 km/h²");
        }

        [Fact]
        public void ToString_ShouldShowSpeedAsStringWithUnit_When_IsInvoked()
        {
            // Arrange
            Acceleration sut;

            // Act
            sut = new Acceleration(18000);

            // Assert
            sut.ToString().Should().Be("18000 km/h²");
        }
    }
}

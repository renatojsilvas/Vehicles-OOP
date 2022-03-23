using FluentAssertions;
using System;
using Vehicles.Domain.Exceptions;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Models
{
    public class SpeedTests
    {
        [Fact]
        public void Speed_ShouldBeCreatedSuccesfully_When_ItIsZerokmPerHour()
        {
            // Arrange
            Speed sut;

            // Act
            sut = new Speed(0);

            // Assert
            sut.Value.Should().Be(0);
        }

        [Fact]
        public void Speed_ShouldBeCreatedSuccesfully_When_ItIs300kmPerHour()
        {
            // Arrange
            Speed sut;

            // Act
            sut = new Speed(300);

            // Assert
            sut.Value.Should().Be(300);
        }

        [Fact]
        public void Unit_ShouldBekmPerHourByDefault_When_AnySpeedIsCreated()
        {
            // Arrange
            Speed sut;

            // Act
            sut = new Speed(300);

            // Assert
            sut.Unit.Should().Be("km/h");
        }

        [Fact]
        public void Speed_ShouldBeThrownAnInvalidSpeedException_When_ItIsGreaterThan300kmPerHour()
        {
            // Arrange

            // Act 
            Action sut = () => new Speed(301);

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidQuantityException>()
                               .WithMessage("The speed must be greater or equal 0 km/h and less or equal than 300 km/h");
        }

        [Fact]
        public void Speed_ShouldBeThrownAnInvalidSpeedException_When_ItIsLessThanZero()
        {
            // Arrange

            // Act 
            Action sut = () => new Speed(-1);

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidQuantityException>()
                               .WithMessage("The speed must be greater or equal 0 km/h and less or equal than 300 km/h");
        }

        [Fact]
        public void ToString_ShouldShowSpeedAsStringWithUnit_When_IsInvoked()
        {
            // Arrange
            Speed sut;

            // Act
            sut = new Speed(300);

            // Assert
            sut.ToString().Should().Be("300 km/h");
        }
    }
}

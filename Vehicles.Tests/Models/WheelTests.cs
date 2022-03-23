using FluentAssertions;
using System;
using Vehicles.Domain.Exceptions;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Models
{
    public class WheelTests
    {
        [Fact]
        public void Wheel_ShouldBeCreateSuccesfully_When_SizeIsGreaterThanTenInches()
        {
           // Arrange
            Wheel sut;
            
            // Act
            sut = new Wheel(new Size(10));

            // Assert
            sut.Size.Should().Be(new Size(10));
        }

        [Fact]
        public void Equals_ShouldBeTrue_When_CompareTwoWheelAndTheyAreEqual()
        {
            // Arrange
            Wheel wheel1 = new Wheel(new Size(10));
            Wheel wheel2 = new Wheel(new Size(10));

            // Act
            var result = wheel1.Equals(wheel2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_ShouldBeFalse_When_CompareTwoWheelAndTheyAreNotEqual()
        {
            // Arrange
            Wheel wheel1 = new Wheel(new Size(10));
            Wheel wheel2 = new Wheel(new Size(11));

            // Act
            var result = wheel1.Equals(wheel2);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldBeFalse_When_CompareWheelToAnotherObjectInsteadOfWheel()
        {
            // Arrange
            Wheel wheel1 = new Wheel(new Size(10));
            object anotherInstance = new object();

            // Act
            var result = wheel1.Equals(anotherInstance);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void GetHahsCode_ShouldBeEqual_When_TwoWheelAreEqual()
        {
            // Arrange
            Wheel wheel1 = new Wheel(new Size(10));
            Wheel wheel2 = new Wheel(new Size(10));

            // Act
            var result = wheel1.GetHashCode().Equals(wheel2.GetHashCode());

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Wheel_ShouldBeThrownInvalidWheelSizeException_When_SizeIsLessThanTenInches()
        {
            // Arrange

            // Act 
            Action sut = () => new Wheel(new Size(9));

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidWheelSizeException>()
                               .WithMessage("The wheel size must be greater or equal than 10 \"");
        }
    }
}

using FluentAssertions;
using System;
using Vehicles.Domain.Exceptions;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Models
{
    public class WheelsTests
    {
        [Fact]
        public void Wheels_CreateTwoWheelsWithTheSameSize()
        {
            // Arrange
            Wheels sut;

            // Act
            sut = new Wheels(2, new Size(13));

            // Assert
            sut.NumberOfWheels.Should().Be(2);
            sut[0].Size.Should().Be(new Size(13));
            sut[1].Size.Should().Be(new Size(13));
        }

        [Fact]
        public void Wheels_CreateFourWheelsWithTheSameSize()
        {
            // Arrange
            Wheels sut;

            // Act
            sut = new Wheels(4, new Size(13));

            // Assert
            sut.NumberOfWheels.Should().Be(4);
            sut[0].Size.Should().Be(new Size(13));
            sut[1].Size.Should().Be(new Size(13));
            sut[2].Size.Should().Be(new Size(13));
            sut[3].Size.Should().Be(new Size(13));
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenTwoWheelsAreEqual()
        {
            // Arrange
            Wheels wheels1 = new Wheels(4, new Size(10));
            Wheels wheels2 = new Wheels(4, new Size(10));

            // Act
            var result = wheels1.Equals(wheels2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenTwoWheelsAreNotEqual()
        {
            // Arrange
            Wheels wheels1 = new Wheels(4, new Size(10));
            Wheels wheels2 = new Wheels(6, new Size(10));

            // Act
            var result = wheels1.Equals(wheels2);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenCompareWheelsToAnotherInstanceInsteadOfWheels()
        {
            // Arrange
            Wheels wheels1 = new Wheels(4, new Size(10));
            object anotherInstance = new object();

            // Act
            var result = wheels1.Equals(anotherInstance);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void GetHashCode_ShouldReturnTrue_WhenTwoWheelsAreEqual()
        {
            // Arrange
            Wheels wheels1 = new Wheels(4, new Size(10));
            Wheels wheels2 = new Wheels(4, new Size(10));

            // Act
            var result = wheels1.GetHashCode().Equals(wheels2.GetHashCode());

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Wheel_ShouldBeThrownInvalidNumberOfWheelsException_When_SizeIsZero()
        {
            // Arrange

            // Act 
            Action sut = () => new Wheels(0, new Size(13));

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidNumberOfWheelsException>()
                               .WithMessage("The number of wheels must be greater than zero and even");
        }

        [Fact]
        public void Wheel_ShouldBeThrownInvalidNumberOfWheelsException_When_SizeIsNegative()
        {
            // Arrange

            // Act 
            Action sut = () => new Wheels(-1, new Size(13));

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidNumberOfWheelsException>()
                               .WithMessage("The number of wheels must be greater than zero and even");
        }

        [Fact]
        public void Wheel_ShouldBeThrownInvalidNumberOfWheelsException_When_SizeIsOne()
        {
            // Arrange

            // Act 
            Action sut = () => new Wheels(1, new Size(13));

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidNumberOfWheelsException>()
                               .WithMessage("The number of wheels must be greater than zero and even");
        }

        [Fact]
        public void Wheel_ShouldBeThrownInvalidNumberOfWheelsException_When_SizeIsThree()
        {
            // Arrange

            // Act 
            Action sut = () => new Wheels(3, new Size(13));

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidNumberOfWheelsException>()
                               .WithMessage("The number of wheels must be greater than zero and even");
        }
    }
}

using FluentAssertions;
using System;
using Vehicles.Domain.Exceptions;
using Vehicles.Domain.Model;
using Xunit;

namespace Vehicles.Tests.Models
{
    public class SizeTests
    {
        [Fact]
        public void Size_ShouldBeCreatedSuccesfully_When_ItIsOneInches()
        {
            // Arrange
            Size sut;

            // Act
            sut = new Size(1);

            // Assert
            sut.Value.Should().Be(1);
        }

        [Fact]
        public void Unit_ShouldBekmPerHourByDefault_When_AnySizeIsCreated()
        {
            // Arrange
            Size sut;

            // Act
            sut = new Size(30);

            // Assert
            sut.Unit.Should().Be("\"");
        }

        [Fact]
        public void Size_ShouldBeThrownAnInvalidSizeException_When_ItIsLessThanZero()
        {
            // Arrange

            // Act 
            Action sut = () => new Size(-1);

            // Assert
            var exception = sut.Should()
                               .Throw<InvalidQuantityException>()
                               .WithMessage("The size must be greater or equal than 1 \"");
        }

        [Fact]
        public void ToString_ShouldShowSizeAsStringWithUnit_When_IsInvoked()
        {
            // Arrange
            Size sut;

            // Act
            sut = new Size(300);

            // Assert
            sut.ToString().Should().Be("300 \"");
        }

        [Fact]
        public void GetHashCode_ShouldGetHashCode()
        {
            // Arrange
            Size size1;
            Size size2;

            // Act
            size1 = new Size(300);
            size2 = new Size(300);

            // Assert
            size1.GetHashCode().Should().Be(size2.GetHashCode());
        }

        [Fact]
        public void GreaterOperator_ShouldReturnTrue_When_Size2IsGreaterThanSize1()
        {
            // Arrange
            Size size1 = new Size(300); 
            Size size2 = new Size(301); 

            // Act
            var result = size2 > size1;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void GreaterOperator_ShouldReturnFalse_When_Size1IsGreaterThanSize2()
        {
            // Arrange
            Size size1 = new Size(301);
            Size size2 = new Size(300);

            // Act
            var result = size2 > size1;

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void LessOperator_ShouldReturnTrue_When_Size2IsLessThanSize1()
        {
            // Arrange
            Size size1 = new Size(301);
            Size size2 = new Size(300);

            // Act
            var result = size2 < size1;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void LessOperator_ShouldReturnFalse_When_Size1IsLessThanSize2()
        {
            // Arrange
            Size size1 = new Size(300);
            Size size2 = new Size(301);

            // Act
            var result = size2 < size1;

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldReturnFalse_When_CompareFromInstanceInsteadQuantity()
        {
            // Arrange
            Size size1 = new Size(300);
            object instance = new object();

            // Act
            var result = size1.Equals(instance);

            // Assert
            result.Should().BeFalse();
        }
    }
}

using FluentAssertions;
using Vehicles.Domain.Exceptions;
using Xunit;

namespace Vehicles.Tests.Exceptions
{
    public class InvalidQuantityExceptionTests
    {
        [Fact]
        public void Message_ShouldGetMessageForMinAndMaxValues_When_MinAndMaxValuesAreNotExtremeValues()
        {
            // Arrange
            InvalidQuantityException sut;


            // Act
            sut = new InvalidQuantityException("quantity", 0, 1, "unit");

            // Assert
            sut.Message.Should().Be("The quantity must be greater or equal 0 unit and less or equal than 1 unit");
        }

        [Fact]
        public void Message_ShouldGetMessageForMinValue_When_MaxValueIsExtreme()
        {
            // Arrange
            InvalidQuantityException sut;


            // Act
            sut = new InvalidQuantityException("quantity", 0, int.MaxValue, "unit");

            // Assert
            sut.Message.Should().Be("The quantity must be greater or equal than 0 unit");
        }

        [Fact]
        public void Message_ShouldGetMessageForMaxValue_When_MinValuesIsExtreme()
        {
            // Arrange
            InvalidQuantityException sut;


            // Act
            sut = new InvalidQuantityException("quantity", int.MinValue, 1, "unit");

            // Assert
            sut.Message.Should().Be("The quantity must be less or equal than 1 unit");
        }
    }
}

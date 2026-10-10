using DevelopmentCeti.Core.Parking;

namespace DevelopmentCeti.Tests.Parking;

public class ParkingRequestValidatorTests
{
    [Fact]
    public void Validate_WhenLicensePlateIsEmpty_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ParkingRequestValidator();
        var licensePlate = "";

        // Act
        var result = validator.Validate(licensePlate);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("   ", false)]
    [InlineData(null, false)]
    [InlineData("ABC-123", true)]
    [InlineData("JAL-456", true)]
    public void Validate_WhenLicensePlateIsProvided_ShouldReturnExpectedResult(
        string? licensePlate,
        bool expected)
    {
        // Arrange
        var validator = new ParkingRequestValidator();

        // Act
        var result = validator.Validate(licensePlate);

        // Assert
        Assert.Equal(expected, result);
    }
}
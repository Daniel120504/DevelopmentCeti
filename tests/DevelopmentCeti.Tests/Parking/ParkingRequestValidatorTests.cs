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
}
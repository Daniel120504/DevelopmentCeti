namespace DevelopmentCeti.Core.Parking;

public class ParkingRequestValidator
{
    public bool Validate(string? licensePlate) =>
        !string.IsNullOrWhiteSpace(licensePlate);
}
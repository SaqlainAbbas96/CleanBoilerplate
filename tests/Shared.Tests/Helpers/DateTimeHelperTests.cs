using Shared.Helpers;

namespace Shared.Tests.Helpers;

/// <summary>
/// Unit tests for the DateTimeHelper class.
/// </summary>
public class DateTimeHelperTests
{
    [Fact]
    public void GetCurrentUtcTime_ShouldReturnUtcNow()
    {
        // Arrange
        var expectedUtcNow = DateTime.UtcNow;

        // Act
        var actualUtcNow = DateTimeHelper.GetCurrentUtcTime();

        // Assert
        Assert.Equal(expectedUtcNow.ToString("yyyy-MM-dd HH:mm:ss"), actualUtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    [Fact]
    public void ConvertToTimeZone_ShouldReturnCorrectTimeForValidTimeZone()
    {
        // Arrange
        var utcTime = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var timeZoneId = "Eastern Standard Time"; // UTC-5

        // Act
        var result = DateTimeHelper.ConvertToTimeZone(utcTime, timeZoneId);

        // Assert
        Assert.Equal(new DateTime(2024, 1, 1, 7, 0, 0), result);
    }

    [Fact]
    public void ConvertToTimeZone_ShouldThrowExceptionForInvalidTimeZone()
    {
        // Arrange
        var utcTime = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var invalidTimeZoneId = "Invalid/TimeZone";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            DateTimeHelper.ConvertToTimeZone(utcTime, invalidTimeZoneId));

        Assert.Contains("Time zone 'Invalid/TimeZone' not found.", exception.Message);
    }

    [Fact]
    public void CalculateDuration_ShouldReturnCorrectTimeSpan()
    {
        // Arrange
        var startTime = new DateTime(2024, 1, 1, 10, 0, 0);
        var endTime = new DateTime(2024, 1, 1, 12, 0, 0);

        // Act
        var result = DateTimeHelper.CalculateDuration(startTime, endTime);

        // Assert
        Assert.Equal(TimeSpan.FromHours(2), result);
    }

    [Fact]
    public void IsWithinRange_ShouldReturnTrueIfWithinRange()
    {
        // Arrange
        var dateTime = new DateTime(2024, 1, 1, 12, 0, 0);
        var startRange = new DateTime(2024, 1, 1, 10, 0, 0);
        var endRange = new DateTime(2024, 1, 1, 14, 0, 0);

        // Act
        var result = DateTimeHelper.IsWithinRange(dateTime, startRange, endRange);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWithinRange_ShouldReturnFalseIfOutOfRange()
    {
        // Arrange
        var dateTime = new DateTime(2024, 1, 1, 15, 0, 0);
        var startRange = new DateTime(2024, 1, 1, 10, 0, 0);
        var endRange = new DateTime(2024, 1, 1, 14, 0, 0);

        // Act
        var result = DateTimeHelper.IsWithinRange(dateTime, startRange, endRange);

        // Assert
        Assert.False(result);
    }
}

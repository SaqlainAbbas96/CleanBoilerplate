namespace Shared.Helpers
{
    /// <summary>
    /// Provides utility methods for working with DateTime objects, including time zone conversion,
    /// duration calculation, and range checking.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Gets the current UTC time.
        /// </summary>
        /// <returns>The current UTC DateTime.</returns>
        public static DateTime GetCurrentUtcTime()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Converts a DateTime to a specified time zone.
        /// </summary>
        /// <param name="dateTime">The original DateTime.</param>
        /// <param name="timeZoneId">The target time zone ID (e.g., "Eastern Standard Time").</param>
        /// <returns>The DateTime adjusted to the specified time zone.</returns>
        public static DateTime ConvertToTimeZone(DateTime dateTime, string timeZoneId)
        {
            try
            {
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return TimeZoneInfo.ConvertTime(dateTime, timeZoneInfo);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException($"Time zone '{timeZoneId}' not found.");
            }
            catch (InvalidTimeZoneException)
            {
                throw new ArgumentException($"Time zone '{timeZoneId}' is invalid.");
            }
        }

        /// <summary>
        /// Calculates the difference between two DateTimes.
        /// </summary>
        /// <param name="start">The start DateTime.</param>
        /// <param name="end">The end DateTime.</param>
        /// <returns>The duration as a TimeSpan.</returns>
        public static TimeSpan CalculateDuration(DateTime start, DateTime end)
        {
            return end - start;
        }

        /// <summary>
        /// Formats a DateTime to a string using the specified format.
        /// </summary>
        /// <param name="dateTime">The DateTime to format.</param>
        /// <param name="format">The format string (e.g., "yyyy-MM-dd HH:mm:ss").</param>
        /// <returns>The formatted DateTime string.</returns>
        public static string FormatDateTime(DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// Checks if a DateTime falls within a specified range.
        /// </summary>
        /// <param name="dateTime">The DateTime to check.</param>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        /// <returns>True if the DateTime is within the range; otherwise, false.</returns>
        public static bool IsWithinRange(DateTime dateTime, DateTime start, DateTime end)
        {
            return dateTime >= start && dateTime <= end;
        }
    }
}

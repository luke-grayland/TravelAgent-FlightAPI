using System.Text.RegularExpressions;

namespace TravelAgent_FlightAPI.Utilities;

public static class Iso8601DurationToTime
{
    private static readonly Regex DurationRegex = new Regex(
        @"^P(?:(?<Years>\d+)Y)?(?:(?<Months>\d+)M)?(?:(?<Days>\d+)D)?" +
        @"(?:T(?:(?<Hours>\d+)H)?(?:(?<Minutes>\d+)M)?(?:(?<Seconds>\d+)S)?)?$",
        RegexOptions.Compiled);

    /// <summary>
    /// Converts an ISO8601 duration string into hh:mm format.
    /// Rolls years, months, and days into hours.
    /// </summary>
    public static string ToHourMinute(string isoDuration)
    {
        if (string.IsNullOrWhiteSpace(isoDuration))
            throw new ArgumentNullException(nameof(isoDuration));

        var match = DurationRegex.Match(isoDuration);
        if (!match.Success)
            throw new FormatException($"Invalid ISO8601 duration format: {isoDuration}");

        int years = ParseGroup(match, "Years");
        int months = ParseGroup(match, "Months");
        int days = ParseGroup(match, "Days");
        int hours = ParseGroup(match, "Hours");
        int minutes = ParseGroup(match, "Minutes");
        int seconds = ParseGroup(match, "Seconds");

        // Convert everything into total hours + minutes
        long totalHours = 0;

        totalHours += years * 365 * 24;   // 1 year = 365 days
        totalHours += months * 30 * 24;   // 1 month = 30 days
        totalHours += days * 24;
        totalHours += hours;

        // Handle rounding if seconds >= 30
        if (seconds >= 30)
        {
            minutes++;
        }

        // If minutes overflow, carry to hours
        if (minutes >= 60)
        {
            totalHours += minutes / 60;
            minutes = minutes % 60;
        }

        return $"{totalHours:D2}:{minutes:D2}";
    }

    private static int ParseGroup(Match match, string groupName)
    {
        return int.TryParse(match.Groups[groupName].Value, out var value) ? value : 0;
    }
}
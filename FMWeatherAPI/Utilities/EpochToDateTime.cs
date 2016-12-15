using System;

namespace FMWeatherAPI
{
    public class EpochToDateTime
    {
        /// <summary>
        /// Converts a DateTime to the long representation which is the number of seconds since the unix epoch.
        /// </summary>
        /// <param name="dateTime">A DateTime to convert to epoch time.</param>
        /// <returns>The long number of seconds since the unix epoch.</returns>
        public static long ToEpoch(DateTime dateTime) => (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;

        /// <summary>
        /// Converts a long representation of time since the unix epoch to a DateTime.
        /// </summary>
        /// <param name="epoch">The number of seconds since Jan 1, 1970.</param>
        /// <returns>A DateTime representing the time since the epoch.</returns>
        public static DateTime FromEpoch(long epoch) => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddSeconds(epoch);

        /// <summary>
        /// Converts a long? representation of time since the unix epoch to a DateTime?.
        /// </summary>
        /// <param name="epoch">The number of seconds since Jan 1, 1970.</param>
        /// <returns>A DateTime? representing the time since the epoch.</returns>
        public static DateTime? FromEpoch(long? epoch) => epoch.HasValue ? (DateTime?)FromEpoch(epoch.Value) : null;

        /// <summary>
        /// Converts a long representation of time since the unix epoch to a DateTime.
        /// </summary>
        /// <param name="epoch">The number of seconds since Jan 1, 1970.</param>
        /// <returns>A DateTime representing the time since the epoch.</returns>
        private static DateTime FromEpoch(string epoch) => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddSeconds(Convert.ToInt64(epoch));

        /// <summary>
        /// Converts a string representation of time since the unix epoch to a DateTime?.
        /// </summary>
        /// <param name="epoch">The number of seconds since Jan 1, 1970.</param>
        /// <returns>A DateTime? representing the time since the epoch.</returns>
        public static DateTime? FromEpochString(string epoch) => string.IsNullOrWhiteSpace(epoch) ?  null : (DateTime?)FromEpoch(Convert.ToInt64(epoch));
    }
}
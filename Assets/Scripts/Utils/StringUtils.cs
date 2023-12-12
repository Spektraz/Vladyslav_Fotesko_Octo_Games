using System;

namespace Utils
{
    public static class StringUtils
    {
        public const int HOURS_PER_DAY = 24;

        public static string TimeSpanToFormattedString(TimeSpan timeSpan)
        {
            if (timeSpan.Hours > 0)
            {
                return timeSpan.ToString(@"h\:mm\:ss");
            }

            return timeSpan.ToString(@"m\:ss");
        }

        public static string TimeSpanToFormattedStringMinSec(TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"mm\:ss");
        }
        public static string GetDayTimeSpanFormatted(TimeSpan timeSpan)
        {
            if (timeSpan.Days > 0)
            {
                return string.Format($"{timeSpan.Days * HOURS_PER_DAY + timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}");
            }
            else
            {
                return timeSpan.ToString(@"%h\:mm\:ss");
            }
        }

        public static string BoolToYesNo(bool value)
        {
            return value ? "yes" : "no";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Core
{
    public static class TimestampBuilder
    {
        public static string GenerateUniqueText(string text)
        {
            var newTimestamp = GenerateUniqueText();
            var result = string.Concat(text, newTimestamp);
            return result;
        }

        public static string GenerateUniqueText()
        {
            var newTimestamp = DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss-ffff");
            return newTimestamp;
        }

        public static string GenerateUniqueTextMonthNameOneWord()
        {
            var newTimestamp = DateTime.Now.ToString("MMMMddyyyyhhmmss");
            return newTimestamp;
        }
    }
}

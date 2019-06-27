using System;

namespace DataAccess.Core
{
    public static class UniqueEmailGenerator
    {
        public static string BuildUniqueEmail(string prefix, string sufix)
        {
            var result = string.Concat(prefix, "_", TimestampBuilder.GenerateUniqueText(), "@", sufix, ".com");
            return result;
        }

        public static string BuildUniqueEmailTimestamp()
        {
            var result = $"atp-{TimestampBuilder.GenerateUniqueText()}@bellatrix.com";
            return result;
        }

        public static string BuildUniqueEmailGuid()
        {
            var result = $"atp-{Guid.NewGuid()}@bellatrix.com";
            return result;
        }

        public static string BuildUniqueEmail(string prefix)
        {
            var result = $"{prefix}{TimestampBuilder.GenerateUniqueText()}@bellatrix.com";
            return result;
        }

        public static string BuildUniqueEmail(char specialSymbol)
        {
            var result = $"atp-{TimestampBuilder.GenerateUniqueText()}{specialSymbol}@bellatrix.com";
            return result;
        }
    }
}

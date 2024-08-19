using System;
using System.Globalization;

namespace ObjLoader.Loader.Common
{
    public static class StringExtensions
    {
        public static float ParseInvariantFloat(this string floatString)
            => float.Parse(floatString, CultureInfo.InvariantCulture.NumberFormat);

        public static int ParseInvariantInt(this string intString)
            => int.Parse(intString, CultureInfo.InvariantCulture.NumberFormat);

        public static bool EqualsOrdinalIgnoreCase(this string str, string s)
            => str.Equals(s, StringComparison.OrdinalIgnoreCase);

        public static bool IsNullOrEmpty(this string str)
            => string.IsNullOrEmpty(str);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smolensk.common
{
    public static class TypeHelper
    {
        public static T? OrdinalToNullable<T>(this T value) where T : struct
        {
            if (HasValue(value))
                return (T?)value;

            return null;
        }

        public static T NullableToOrdinal<T>(this T? value) where T : struct
        {
            if (value.HasValue)
                return value.Value;

            return default(T);
        }

        public static bool HasValue<T>(this T value) where T : struct
        {
            return !value.Equals(default(T));
        }

        public static char? FirstCharacter(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value[0];
        }

        public static char? FirstCharacterLower(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.Substring(0, 1).ToLower()[0];
        }

        public static int? ParseIntNull(this string value, int? def = null)
        {
            if (string.IsNullOrEmpty(value))
                return def;

            int result = -1;

            if (int.TryParse(value, out result))
            {
                return result;
            }

            return def;
        }

    }
}

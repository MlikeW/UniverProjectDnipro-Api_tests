using System;

namespace CommonUtilities.Methods
{
    public static class ParseMethods
    {
        public static bool ToBool(this string str)
        {
            try
            {
                return bool.Parse(str);
            }
            catch
            {
                throw new Exception($"Cannot convert '{str}' to bool.");
            }
        }

        public static int ToInt(this string str)
        {
            try
            {
                return int.Parse(str.Trim());
            }
            catch
            {
                throw new Exception($"Cannot convert '{str}' to int.");
            }
        }
    }
}
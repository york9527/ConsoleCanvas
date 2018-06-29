using System;

namespace ConsoleCanvas.Extentions
{
    public static class StringExtentions
    {
        public static int ToInt(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return -1;

            var result = 0;
            Int32.TryParse(str, out result);
            return result;
        }
    }
}

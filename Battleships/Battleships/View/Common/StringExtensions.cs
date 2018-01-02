using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.View.Common
{
    public static class StringExtensions
    {
        public static IList<string> SplitNewLines(this string str)
        {
            var separator = new String[] {@"\n\r", @"\r\n"};
            return str.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}

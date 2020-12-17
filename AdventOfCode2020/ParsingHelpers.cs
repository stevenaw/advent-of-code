using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class ParsingHelpers
    {
        public static List<int> ParseIntegers(string line, char delim)
        {
            var ids = new List<int>();
            var idSpan = line.AsSpan();

            var nextDelim = idSpan.IndexOf(delim);
            while (!idSpan.IsEmpty && nextDelim != -1)
            {
                var t = idSpan.Slice(0, nextDelim);
                if (Int32.TryParse(t, out var num))
                    ids.Add(num);

                idSpan = idSpan.Slice(t.Length + 1);
                nextDelim = idSpan.IndexOf(delim);
            }

            if (Int32.TryParse(idSpan, out var lastNum))
                ids.Add(lastNum);

            return ids;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec15
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var history = new Dictionary<int, List<int>>();

            var i = 1;
            var prevNumber = 0;

            foreach (var item in ParseIntegers(lines.First(), ','))
            {
                history[item] = new List<int>() {
                    i++
                };
                prevNumber = item;
            }

            while (i <= 2020)
            {
                var prevOccurences = history[prevNumber];
                var nextNumber = prevOccurences.Count == 1 ? 0 : prevOccurences[prevOccurences.Count - 1] - prevOccurences[prevOccurences.Count - 2];

                if (!history.ContainsKey(nextNumber))
                    history[nextNumber] = new List<int>();

                history[nextNumber].Add(i++);
                prevNumber = nextNumber;
            }

            return prevNumber;
        }

        private static List<int> ParseIntegers(string line, char delim)
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

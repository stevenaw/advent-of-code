using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec16
{
    class FuzzyFieldMatch
    {
        public string Name { get; set; }
        public List<Range> Possibilities { get; set; }

        public class Range
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public bool IsInRange(int value) => value >= Min && value <= Max;
        }
    }

    class Parser
    {
        public static IEnumerable<List<int>> ParseTickets(IEnumerator<string> enumerator)
        {
            while (enumerator.MoveNext())
            {
                if (string.IsNullOrEmpty(enumerator.Current) || !char.IsDigit(enumerator.Current[0]))
                    continue;

                yield return ParsingHelpers.ParseIntegers(enumerator.Current, ',');
            }
        }

        public static List<FuzzyFieldMatch> ParseFuzzyMatches(IEnumerator<string> enumerator)
        {
            var result = new List<FuzzyFieldMatch>();

            while (enumerator.MoveNext() && !string.IsNullOrEmpty(enumerator.Current))
            {
                var splits = enumerator.Current.Split(new string[] { ": ", " or " }, StringSplitOptions.RemoveEmptyEntries);

                var fuzzy = new FuzzyFieldMatch()
                {
                    Name = splits[0],
                    Possibilities = new()
                };

                for (var i = 1; i < splits.Length; i++)
                {
                    var minMax = splits[i].Split('-');
                    fuzzy.Possibilities.Add(new()
                    {
                        Min = int.Parse(minMax[0]),
                        Max = int.Parse(minMax[1])
                    });
                }

                result.Add(fuzzy);
            }

            return result;
        }
    }
}

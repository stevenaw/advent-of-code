using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Dec16
{
    class FuzzyFieldMatch
    {
        public string Name { get; set; }
        public List<(int min, int max)> Possibilities { get; set; }
    }

    class Parser
    {
        public static IEnumerable<List<int>> ParseTickets(IEnumerator<string> enumerator)
        {
            while (enumerator.MoveNext())
            {
                if (string.IsNullOrEmpty(enumerator.Current) || !Char.IsDigit(enumerator.Current[0]))
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
                    Possibilities = new List<(int min, int max)>()
                };

                for (var i = 1; i < splits.Length; i++)
                {
                    var minMax = splits[i].Split('-');
                    fuzzy.Possibilities.Add((
                        Int32.Parse(minMax[0]),
                        Int32.Parse(minMax[1])
                    ));
                }

                result.Add(fuzzy);
            }

            return result;
        }
    }
}

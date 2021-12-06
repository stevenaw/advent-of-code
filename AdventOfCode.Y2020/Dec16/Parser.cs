namespace AdventOfCode.Y2020.Dec16
{
    record FuzzyFieldMatch
    {
        public string Name { get; }
        public List<Range> Possibilities { get; }

        public FuzzyFieldMatch(string name)
        {
            Name = name;
            Possibilities = new();
        }

        public record Range
        {
            public int Min { get; init; }
            public int Max { get; init; }
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

                var fuzzy = new FuzzyFieldMatch(splits[0]);

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

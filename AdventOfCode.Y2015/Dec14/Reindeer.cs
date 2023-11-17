using System.Text.RegularExpressions;

namespace AdventOfCode.Y2015.Dec14
{
    partial record Reindeer(string Name, int Speed, int Stamina, int Downtime)
    {
        [GeneratedRegex(@"(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+) seconds.")]
        private static partial Regex Parser();

        public static Reindeer Parse(string s)
        {
            var matches = Parser().Match(s).Groups;
            return new Reindeer(
                matches[1].Value,
                int.Parse(matches[2].ValueSpan),
                int.Parse(matches[3].ValueSpan),
                int.Parse(matches[4].ValueSpan));
        }
    }
}

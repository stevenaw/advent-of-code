using System.Text.RegularExpressions;

namespace AdventOfCode.Y2015.Dec13
{
    record Neighbour(string PersonA, string PersonB, int DeltaHappiness)
    {
        private static readonly Regex Parser = new Regex(@"(\w+) would (gain|lose) (\d+) happiness units by sitting next to (\w+).", RegexOptions.Compiled);

        public static Neighbour Parse(string s)
        {
            var matches = Parser.Match(s).Groups;
            var netGain = matches[2].Value == "gain" ? 1 : -1;

            return new Neighbour(
                matches[1].Value,
                matches[4].Value,
                int.Parse(matches[3].ValueSpan) * netGain);
        }

        public static Neighbour[] ParseMany(IEnumerable<string> lines)
        {
            var scores = lines.Select(Neighbour.Parse).ToList();
            var aggregate = scores.GroupBy(o => o.PersonA.GetHashCode() ^ o.PersonB.GetHashCode())
                .ToDictionary(o => o.Key, o => new Neighbour(o.First().PersonA, o.First().PersonB, o.Sum(o2 => o2.DeltaHappiness)));

            return aggregate.Values.ToArray();
        }
    }
}

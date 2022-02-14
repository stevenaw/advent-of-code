using System.Text.RegularExpressions;

namespace AdventOfCode.Y2016.Dec04
{
    internal static class InputParser
    {
        private static readonly Regex Parser = new Regex(@"^((\w+\-)+)(\d+)\[(\w{5})\]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static InputRecord Parse(string line)
        {
            var matches = Parser.Match(line).Groups;
            return new InputRecord(
                matches[1].Value.TrimEnd('-'),
                int.Parse(matches[3].ValueSpan),
                matches[4].Value
            );
        }

        public record struct InputRecord (string EncryptedName, int SectorId, string Checksum)
        {
            public bool IsValid()
            {
                var charCounts = EncryptedName.Where(e => e != '-').GroupBy(e => e).ToDictionary(e => e.Key, e => e.Count());
                var top5 = charCounts.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(5).Select(o => o.Key).ToArray();

                return Checksum.AsSpan().SequenceEqual(top5);
            }
        }
    }
}

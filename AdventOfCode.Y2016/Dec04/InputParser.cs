using System.Text.RegularExpressions;

namespace AdventOfCode.Y2016.Dec04
{
    internal static class InputParser
    {
        private static readonly Regex Parser = new Regex(@"^((\w+\-)+)(\d+)\[(\w{5})\]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static (string encryptedName, int sectorId, string checksum) Parse(string line)
        {
            var matches = Parser.Match(line).Groups;
            return (
                matches[1].Value.TrimEnd('-'),
                int.Parse(matches[3].ValueSpan),
                matches[4].Value
            );
        }
    }
}

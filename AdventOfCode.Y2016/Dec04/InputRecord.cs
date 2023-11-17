using System.Text.RegularExpressions;

namespace AdventOfCode.Y2016.Dec04
{
    public partial record struct InputRecord(string EncryptedName, int SectorId, string Checksum)
    {
        [GeneratedRegex(@"^((\w+\-)+)(\d+)\[(\w{5})\]$", RegexOptions.IgnoreCase)]
        private static partial Regex Parser();

        public static InputRecord Parse(string line)
        {
            var matches = Parser().Match(line).Groups;
            return new InputRecord(
                matches[1].Value.TrimEnd('-'),
                int.Parse(matches[3].ValueSpan),
                matches[4].Value
            );
        }

        public readonly bool IsValid()
        {
            var charCounts = EncryptedName.Where(e => e != '-').GroupBy(e => e).ToDictionary(e => e.Key, e => e.Count());
            var top5 = charCounts.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(5).Select(o => o.Key).ToArray();

            return Checksum.AsSpan().SequenceEqual(top5);
        }

        public readonly string Decrypt()
        {
            return string.Create(EncryptedName.Length, this, (buffer, state) =>
            {
                var encryptedName = state.EncryptedName;
                for (var i = 0; i < encryptedName.Length; i++)
                {
                    if (encryptedName[i] == '-')
                        buffer[i] = ' ';
                    else
                        buffer[i] = (char)((encryptedName[i] - 'a' + state.SectorId) % 26 + 'a');
                }
            });
        }
    }
}

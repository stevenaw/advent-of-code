namespace AdventOfCode.Y2016.Dec04
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0;

            foreach (var line in lines)
            {
                var (encryptedName, sectorId, checksum) = InputParser.Parse(line);
                if (IsValid(encryptedName, checksum))
                    sum += sectorId;
            }

            return sum;
        }

        private static bool IsValid(string encryptedName, string checksum)
        {
            var charCounts = encryptedName.Where(e => e != '-').GroupBy(e => e).ToDictionary(e => e.Key, e => e.Count());
            var top5 = charCounts.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(5).Select(o => o.Key).ToArray();

            return string.Equals(new string(top5), checksum);
        }
    }
}

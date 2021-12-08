
namespace AdventOfCode.Y2015.Dec05
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var count = 0;

            foreach (var line in lines)
                if (IsNice(line))
                    count++;

            return count;
        }

        private static bool IsNice(string line)
        {
            var naughtyCombo = new[] { "ab", "cd", "pq", "xy" };

            var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
            var vowelsFound = 0;

            bool doubleLetter = false;

            var l = line.AsSpan();
            while (l.Length > 1)
            {
                foreach (var nc in naughtyCombo)
                    if (l.StartsWith(nc))
                        return false;

                doubleLetter = doubleLetter || l[0] == l[1];

                if (vowels.Contains(l[0]))
                    vowelsFound++;

                l = l.Slice(1);
            }

            if (vowels.Contains(l[0]))
                vowelsFound++;

            return doubleLetter && vowelsFound >= 3;
        }
    }
}

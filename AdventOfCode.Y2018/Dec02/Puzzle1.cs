using System.Runtime.CompilerServices;

namespace AdventOfCode.Y2018.Dec02
{
    internal class Puzzle1 : AdventPuzzle
    {
        [SkipLocalsInit]
        protected override long Solve(IEnumerable<string> lines)
        {
            Span<int> counts = stackalloc int[26];

            var twos = 0;
            var threes = 0;

            foreach (var line in lines)
            {
                counts.Clear();

                foreach(var letter in line)
                {
                    counts[letter - 'a']++;
                }

                if (counts.Contains(2))
                {
                    twos++;
                }
                
                if (counts.Contains(3))
                {
                    threes++;
                }
            }

            return twos * threes;
        }
    }
}

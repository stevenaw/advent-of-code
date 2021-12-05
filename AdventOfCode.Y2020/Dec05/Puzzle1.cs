using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec05
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var max = 0;
            foreach (var line in lines)
            {
                var idx = BinaryTranslator.CalculateIndex(line);
                if (idx > max)
                    max = idx;
            }

            return max;
        }
    }
}

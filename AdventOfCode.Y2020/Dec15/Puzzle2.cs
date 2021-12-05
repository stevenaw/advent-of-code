using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2020.Dec15
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var seed = ParsingHelpers.ParseIntegers(lines.First(), ',');
            var result = NumberGenerator.GetNthNumber(seed, 30000000);
            return result;
        }
    }
}

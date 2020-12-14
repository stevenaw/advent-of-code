using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec09
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var numbers = lines.Select(o => Int64.Parse(o)).ToArray();
            var comboBreaker = Helpers.FindFirstToBreakPattern(numbers);

            return comboBreaker;
        }
    }
}

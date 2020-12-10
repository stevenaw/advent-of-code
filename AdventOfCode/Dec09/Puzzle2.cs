using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec09
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var numbers = lines.Select(o => Int64.Parse(o)).ToArray();

            var comboBreaker = Helpers.FindFirstToBreakPattern(numbers);
            var contiguousSum = Helpers.FindContiguousSum(numbers, comboBreaker);

            var items = contiguousSum.ToArray();
            Array.Sort(items);

            return items.First() + items.Last();
        }
    }
}

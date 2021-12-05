using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2020.Dec10
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var numbers = lines.Select(o => long.Parse(o)).OrderBy(o => o).ToList();

            numbers.Insert(0, 0);
            numbers.Add(numbers.Last() + 3);

            var countOneJoltDiff = 0;
            var countThreeJoltDiff = 0;

            for (var i = 1; i < numbers.Count; i++)
            {
                var diff = numbers[i] - numbers[i - 1];

                if (diff == 1)
                    countOneJoltDiff++;
                else if (diff == 3)
                    countThreeJoltDiff++;
            }

            return countOneJoltDiff * countThreeJoltDiff;
        }
    }
}

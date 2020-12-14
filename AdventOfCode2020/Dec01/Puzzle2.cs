using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec01
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> fileContents)
        {
            var numbers = fileContents.Select(o => Int32.Parse(o)).ToArray();

            Array.Sort(numbers);

            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    for (var k = j + 1; k < numbers.Length; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            return numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }
            }

            return 0;
        }
    }
}

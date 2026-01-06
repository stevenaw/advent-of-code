using System;

namespace AdventOfCode.Y2025.Dec06
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.ToList();
            var ranges = PuzzleHelper.BuildRanges(input);

            // Process the input windows one by one
            var results = new List<long>(ranges.Count);
            foreach (var range in ranges)
            {
                // Scan from bottom-up so that we know the operand before we process the numbers
                var operand = input[input.Count - 1].AsSpan(range).Trim()[0];
                var operation = PuzzleHelper.GetOperation(operand);
                long accumulator = operand == '+' ? 0 : 1; // start at 0 for addition, 1 for multiplication

                for (var j = input.Count - 2; j >= 0; j--)
                {
                    var value = long.Parse(input[j].AsSpan(range).Trim());
                    accumulator = operation(accumulator, value);
                }

                results.Add(accumulator);
            }

            return results.Sum();
        }
    }
}

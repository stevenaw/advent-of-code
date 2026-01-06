namespace AdventOfCode.Y2025.Dec06
{
    internal class Puzzle2 : AdventPuzzle
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

                // For each column in the range
                for (var i = range.Start.Value; i < range.End.Value; i++)
                {
                    int startRow = 0;
                    while (input[startRow][i] == ' ')
                    {
                        startRow++;
                    }

                    int endRow = input.Count - 2;
                    while (input[endRow][i] == ' ')
                    {
                        endRow--;
                    }
                    endRow++;

                    long value = 0;
                    var digits = endRow - startRow;
                    while (digits > 0)
                    {
                        var digit = input[endRow - digits][i];
                        value += (digit - '0') * (long)Math.Pow(10, digits-1);
                        digits--;
                    }

                    accumulator = operation(accumulator, value);
                }

                results.Add(accumulator);
            }

            return results.Sum();
        }
    }
}

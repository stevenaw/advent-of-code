namespace AdventOfCode.Y2025.Dec06
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.ToList();
            var expectedLineLength = input[0].Length;

            // Double check all lines are the same length
            for (var i = 1; i < input.Count; i++)
            {
                if (input[i].Length != expectedLineLength)
                {
                    throw new InvalidDataException();
                }
            }

            var boundaries = new List<int>();

            // Traverse across
            for (var j = 0; j < expectedLineLength; j++)
            {
                // Traverse down rows to determine if column if empty
                // Bail early if not
                var allSpaces = true;
                for (var i = 0; i < input.Count && allSpaces; i++)
                {
                    allSpaces = input[i][j] == ' ';
                }

                if (allSpaces)
                {
                    boundaries.Add(j);
                }
            }

            // Put the outside bounds to make parsing easier at next step
            boundaries.Insert(0, 0);
            boundaries.Add(expectedLineLength);

            // Process the input windows one by one
            var results = new List<long>(boundaries.Count - 1);
            for (var i = 1; i < boundaries.Count; i++)
            {
                var range = new Range(boundaries[i - 1], boundaries[i]);

                // Scan from bottom-up so that we know the operand before we process the numbers
                var operand = input[input.Count - 1].AsSpan(range).Trim()[0];
                var operation = GetOperation(operand);
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

        private static Func<long, long, long> GetOperation(char operand)
        {
            switch (operand)
            {
                case '+': return (a, b) => a + b;
                case '*': return (a, b) => a * b;
            }

            throw new ArgumentOutOfRangeException(nameof(operand));
        }
    }
}

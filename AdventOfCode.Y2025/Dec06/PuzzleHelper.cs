namespace AdventOfCode.Y2025.Dec06
{
    public class PuzzleHelper
    {
        public static int GetUniformLineLength(List<string> input)
        {
            var expectedLineLength = input[0].Length;

            // Double check all lines are the same length
            for (var i = 1; i < input.Count; i++)
            {
                if (input[i].Length != expectedLineLength)
                {
                    throw new InvalidDataException();
                }
            }

            return expectedLineLength;
        }

        public static Func<long, long, long> GetOperation(char operand)
        {
            return operand switch
            {
                '+' => (a, b) => a + b,
                '*' => (a, b) => a * b,
                _ => throw new ArgumentOutOfRangeException(nameof(operand)),
            };
        }

        public static List<Range> BuildRanges(List<string> input)
        {
            var boundaries = new List<int>();
            var expectedLineLength = GetUniformLineLength(input);

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
            boundaries.Insert(0, -1);
            boundaries.Add(expectedLineLength);

            List<Range> ranges = new List<Range>();
            for (var i = 1; i < boundaries.Count; i++)
            {
                ranges.Add(new Range(boundaries[i - 1]+1, boundaries[i]));
            }

            return ranges;
        }
    }
}

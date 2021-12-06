using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Y2015.Dec02
{
    internal record Dimensions
    {
        public int Length { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }

        public static bool TryParse(ReadOnlySpan<char> line, [NotNullWhen(true)] out Dimensions? value)
        {
            var dim = ParsingHelpers.ParseIntegers(line, 'x');
            if (dim.Count != 3)
            {
                value = default;
                return false;
            }

            value = new Dimensions()
            {
                Length = dim[0],
                Width = dim[1],
                Height = dim[2]
            };
            return true;
        }
    }
}

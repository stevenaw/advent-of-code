using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Y2015.Dec02
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var total = 0L;

            foreach(var line in lines)
                if (Dimensions.TryParse(line, out var value))
                    total += value.GetSurfaceArea();

            return total;
        }

        private record Dimensions
        {
            public int Length { get; init; }
            public int Width { get; init; }
            public int Height { get; init; }

            public long GetSurfaceArea()
            {
                var a = Length * Width;
                var b = Width * Height;
                var c = Height * Length;

                var extra = Math.Min(a, Math.Min(b, c));

                return 2*a + 2*b + 2*c + extra;
            }

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
}

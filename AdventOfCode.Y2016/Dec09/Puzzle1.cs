using System.Text;

namespace AdventOfCode.Y2016.Dec09
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var line = lines.First().AsSpan();
            var result = new StringBuilder();

            while (!line.IsEmpty)
            {
                var nextExpansion = line.IndexOf('(');
                if (nextExpansion == -1)
                {
                    result.Append(line);
                    line = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    if (nextExpansion != 0)
                    {
                        // eagerly process chars ahead of '('
                        result.Append(line.Slice(0, nextExpansion));
                        line = line.Slice(nextExpansion);
                    }

                    var marker = ParseMarker(line, out var markerLength);
                    var originalCharsProcessed = Expand(line.Slice(markerLength), marker, out var expansion);
                    result.Append(expansion);
                    line = line.Slice(markerLength + originalCharsProcessed);
                }
            }

            return result.Length;
        }

        private static int Expand(ReadOnlySpan<char> chars, Marker marker, out string expansion)
        {
            var toExpand = chars.Slice(0, marker.LetterCount);
            expansion = String.Create(marker.Duplications * toExpand.Length, toExpand.ToString(), (buffer, state) =>
            {
                var j = 0;
                for (var i = 0; i < marker.Duplications; i++)
                {
                    state.CopyTo(buffer.Slice(j, state.Length));
                    j += state.Length;
                }
            });

            return marker.LetterCount;
        }

        private static Marker ParseMarker(ReadOnlySpan<char> chars, out int markerLength)
        {
            var delim = chars.IndexOf('x');
            var lettersToExpand = int.Parse(chars[1..delim]);

            var end = chars.IndexOf(')');
            var numberOfExpansions = int.Parse(chars[(delim + 1)..end]);

            markerLength = end + 1;

            return new Marker(LetterCount: lettersToExpand, Duplications: numberOfExpansions);
        }

        private readonly record struct Marker(int LetterCount, int Duplications);
    }
}

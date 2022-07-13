namespace AdventOfCode.Y2016.Dec09
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            return CalculateExpandedLength(lines.First(), out _);
        }

        private static long CalculateExpandedLength(ReadOnlySpan<char> line, out int charsProcessed)
        {
            var result = 0L;
            var pendingCharsProcessed = 0;

            while (!line.IsEmpty)
            {
                var nextExpansion = line.IndexOf('(');
                if (nextExpansion == -1)
                {
                    pendingCharsProcessed = line.Length;
                    result += line.Length;
                    line = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    // Consume any chars ahead of '(' if they exist
                    // If 0, these are noops
                    result += nextExpansion;
                    pendingCharsProcessed += nextExpansion;
                    line = line.Slice(nextExpansion);

                    // Parse marker and move pointer forward
                    var marker = ParseMarker(line, out var markerLength);
                    line = line.Slice(markerLength);
                    pendingCharsProcessed += markerLength;

                    // Extract part to expand, calculate size of single expansion, then multiple by the number of expansions
                    var toExpand = line.Slice(0, marker.LetterCount);
                    var expandedLength = CalculateExpandedLength(toExpand, out var subCharsProcessed);
                    line = line.Slice(subCharsProcessed);
                    result += expandedLength * marker.Duplications;
                    pendingCharsProcessed += subCharsProcessed;
                }
            }

            charsProcessed = pendingCharsProcessed;
            return result;
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

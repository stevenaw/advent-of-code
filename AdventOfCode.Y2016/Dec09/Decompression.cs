namespace AdventOfCode.Y2016.Dec09
{
    internal static class Decompression
    {
        internal static long CalculateExpandedLength(ReadOnlySpan<char> line, bool recursive = false)
            => Decompression.CalculateExpandedLength(line, out _, recursive);

        private static long CalculateExpandedLength(ReadOnlySpan<char> line, out int charsProcessed, bool recursive)
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

                    if (recursive)
                    {
                        // Extract part to expand, calculate size of single expansion, then multiple by the number of expansions
                        var toExpand = line.Slice(0, marker.LetterCount);
                        var expandedLength = CalculateExpandedLength(toExpand, out var subCharsProcessed, recursive);
                        line = line.Slice(subCharsProcessed);
                        result += expandedLength * marker.Duplications;
                        pendingCharsProcessed += subCharsProcessed;
                    }
                    else
                    {
                        line = line.Slice(marker.LetterCount);
                        result += marker.LetterCount * marker.Duplications;
                        pendingCharsProcessed += marker.LetterCount;
                    }
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

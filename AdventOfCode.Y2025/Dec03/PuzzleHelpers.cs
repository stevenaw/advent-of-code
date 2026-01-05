namespace AdventOfCode.Y2025.Dec03
{
    internal static class PuzzleHelpers
    {
        internal static long GetMaxJoltage(ReadOnlySpan<char> line, int digits)
        {
            Span<char> buffer = stackalloc char[digits];
            var previousIdx = 0;

            for (var i = 0; i < digits; i++)
            {
                var startIdx = line.Length - digits + i + 1;

                var window = line[previousIdx..startIdx];
                var idx = FindIndexOfHighestDigit(window) + previousIdx;

                buffer[i] = line[idx];
                previousIdx = idx + 1;
            }

            return long.Parse(buffer);
        }

        private static int FindIndexOfHighestDigit(ReadOnlySpan<char> line)
        {
            char highestDigit = '0';
            int firstDigitPos = -1;

            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] > highestDigit)
                {
                    highestDigit = line[i];
                    firstDigitPos = i;

                    if (highestDigit == '9')
                    {
                        break;
                    }
                }
            }

            return firstDigitPos;
        }
    }
}

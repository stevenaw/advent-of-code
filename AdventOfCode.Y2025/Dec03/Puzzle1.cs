namespace AdventOfCode.Y2025.Dec03
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            return lines.Sum(x => GetMaxJoltage(x));
        }

        private static int GetMaxJoltage(ReadOnlySpan<char> line)
        {
            var firstIdx = FindIndexOfHighestDigit(line);

            if (firstIdx == line.Length - 1)
            {
                // Highest digit is already in the last position.
                // Slice off the other part and refind the highest there
                firstIdx = FindIndexOfHighestDigit(line.Slice(0, line.Length - 1));
            }

            var secondIdx = FindIndexOfHighestDigit(line.Slice(firstIdx + 1)) + firstIdx + 1;

            var firstDigit = line[firstIdx] - '0';
            var secondDigit = line[secondIdx] - '0';

            return firstDigit * 10 + secondDigit;


            static int FindIndexOfHighestDigit(ReadOnlySpan<char> line)
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
}

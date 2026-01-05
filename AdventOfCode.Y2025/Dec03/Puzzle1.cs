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
            // slice off last character to ensure we don't pick the last digit as highest first
            var firstIdx = FindIndexOfHighestDigit(line[..^1]);
            var secondIdx = FindIndexOfHighestDigit(line[(firstIdx + 1)..]) + firstIdx + 1;

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

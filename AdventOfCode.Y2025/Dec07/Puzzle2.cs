namespace AdventOfCode.Y2025.Dec07
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var buffer = lines.Select(x => x.ToCharArray()).ToArray();
            var beamCounts = new long[buffer[0].Length];

            // Normalize the start 
            var startIdx = buffer[0].IndexOf('S');
            buffer[0][startIdx] = '|';
            beamCounts[startIdx] = 1;

            for (var i = 1; i < buffer.Length; i++)
            {
                for (int j = 0; j < buffer[i].Length; j++)
                {
                    char above = buffer[i - 1][j];
                    char current = buffer[i][j];

                    if (above == '|' && current == '.')
                    {
                        buffer[i][j] = '|';
                    }
                    else if (above == '|' && current == '^')
                    {
                        buffer[i][j - 1] = '|';
                        beamCounts[j - 1] += beamCounts[j];

                        buffer[i][j + 1] = '|';
                        beamCounts[j + 1] += beamCounts[j];

                        beamCounts[j] = 0;
                    }
                }
            }

            return beamCounts.Sum();
        }
    }
}

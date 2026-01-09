namespace AdventOfCode.Y2025.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            int splitCount = 0;

            var buffer = lines.Select(x => x.ToCharArray()).ToArray();

            // Normalize the start 
            var startIdx = buffer[0].IndexOf('S');
            buffer[0][startIdx] = '|';

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
                        buffer[i][j + 1] = '|';
                        splitCount++;
                    }
                }
            }

            return splitCount;
        }
    }
}

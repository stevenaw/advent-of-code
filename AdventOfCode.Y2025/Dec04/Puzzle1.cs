namespace AdventOfCode.Y2025.Dec04
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var grid = Grid.BuildGrid(lines);
            var count = 0;

            for (var i = 0; i < grid.Height; i++)
            {
                for (var j = 0; j < grid.Width; j++)
                {
                    if (!grid[j, i])
                    {
                        continue;
                    }

                    var neighbors = grid.CountNeighbors(j, i);
                    if (neighbors < 4)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}

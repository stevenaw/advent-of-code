namespace AdventOfCode.Y2025.Dec04
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var grid = Grid.BuildGrid(lines);
            var removed = 0;
            var totalRemoved = 0;

            do
            {
                var newGrid = grid.DeepClone();
                removed = 0;

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
                            newGrid[j, i] = false;
                            removed++;
                        }
                    }
                }

                totalRemoved += removed;
                grid = newGrid;
            } while (removed > 0);

            return totalRemoved;
        }
    }
}

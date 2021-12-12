namespace AdventOfCode.Y2015.Dec06
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int Rows = 1000;
            const int Columns = 1000;
            var grid = new int[Rows * Columns];

            foreach (var line in lines)
            {
                var op = Operation.Parse(line);

                for (var y = op.Start.Y; y <= op.End.Y; y++)
                {
                    for (var x = op.Start.X; x <= op.End.X; x++)
                    {
                        switch (op.Action)
                        {
                            case Action.On:
                                grid[y * Rows + x]++;
                                break;
                            case Action.Off:
                                grid[y * Rows + x] = Math.Max(grid[y * Rows + x]-1, 0);
                                break;
                            case Action.Toggle:
                                grid[y * Rows + x] += 2;
                                break;
                        }
                    }
                }
            }

            var count = 0L;
            for (var i = 0; i < grid.Length; i++)
                count += grid[i];

            return count;
        }
    }
}

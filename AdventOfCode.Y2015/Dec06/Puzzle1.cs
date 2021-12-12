namespace AdventOfCode.Y2015.Dec06
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int Rows = 1000;
            const int Columns = 1000;
            var grid = new bool[Rows * Columns];

            foreach (var line in lines)
            {
                var op = Operation.Parse(line);

                for (var y = op.Start.Y; y <= op.End.Y; y++)
                {
                    switch (op.OpCode)
                    {
                        case OpCode.On:
                            Array.Fill(grid, true, y * Rows + op.Start.X, op.End.X - op.Start.X + 1);
                            break;
                        case OpCode.Off:
                            Array.Fill(grid, false, y * Rows + op.Start.X, op.End.X - op.Start.X + 1);
                            break;
                        case OpCode.Toggle:
                            for (var x = op.Start.X; x <= op.End.X; x++)
                                grid[y * Rows + x] = !grid[y * Rows + x];
                            break;
                    }

                    //for (var x = op.Start.X; x <= op.End.X; x++)
                    //{
                    //    switch(op.OpCode)
                    //    {
                    //        case OpCode.On:
                    //            grid[y * Rows + x] = true;
                    //            break;
                    //        case OpCode.Off:
                    //            grid[y * Rows + x] = false;
                    //            break;
                    //        case OpCode.Toggle:
                    //            grid[y * Rows + x] = !grid[y * Rows + x];
                    //            break;
                    //    }
                    //}
                }
            }

            var count = 0;
            for (var i = 0; i < grid.Length; i++)
                if (grid[i])
                    count++;

            return count;
        }
    }
}

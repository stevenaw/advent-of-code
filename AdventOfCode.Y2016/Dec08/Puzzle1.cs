namespace AdventOfCode.Y2016.Dec08
{
    internal class Puzzle1 : AdventPuzzle
    {
        const int Width = 50;
        const int Height = 6;

        protected override long Solve(IEnumerable<string> lines)
        {
            var grid = new bool[Height * Width];

            foreach (var line in lines)
            {
                Operate(line, grid);
                Output(line, grid);
            }

            return grid.Count(g => g);
        }

        private static void Output (string command, bool[] grid)
        {
            Console.WriteLine(command);

            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                    Console.Write(grid[row * Width + col] ? 'X' : '.');
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void Operate(string command, bool[] grid)
        {
            var (Op, Arg0, Arg1) = Parse(command);

            switch (Op)
            {
                case Operation.Rect:
                    {
                        for (var row = 0; row < Arg1; row++)
                            Array.Fill(grid, true, row * Width, Arg0);
                    }
                    break;
                case Operation.ShiftVertical:
                    {
                        var newValues = new bool[Height];
                        for (var i = 0; i < Height; i++)
                        {
                            var oldIdx = (i * Width) + Arg0;
                            var newIdx = (i + Arg1) % Height;
                            newValues[newIdx] = grid[oldIdx];
                        }

                        for (var i = 0; i < Height; i++)
                            grid[(i * Width) + Arg0] = newValues[i];
                    }
                    break;
                case Operation.ShiftHorizontal:
                    {
                        var newValues = new bool[Width];
                        for (var i = 0; i < Width; i++)
                        {
                            var oldIdx = (Arg0 * Width) + i;
                            var newIdx = (i + Arg1) % Width;
                            newValues[newIdx] = grid[oldIdx];
                        }

                        newValues.CopyTo(grid, (Arg0 * Width));
                    }
                    break;
            }
        }

        private static (Operation op, int arg0, int arg1) Parse(string command)
        {
            var sliceable = command.AsSpan().Trim();

            Operation op;
            int arg0, arg1;

            if (sliceable.StartsWith("rect"))
            {
                op = Operation.Rect;

                var delim = sliceable.LastIndexOf('x');
                arg1 = int.Parse(sliceable.Slice(delim+1));

                sliceable = sliceable.Slice(0, delim);
                var secondDelim = sliceable.LastIndexOf(' ');
                arg0 = int.Parse(sliceable.Slice(secondDelim + 1));
            }
            else
            {
                op = sliceable.StartsWith("rotate column") ? Operation.ShiftVertical : Operation.ShiftHorizontal;

                var delim = sliceable.LastIndexOf(' ');
                arg1 = int.Parse(sliceable.Slice(delim + 1));

                sliceable = sliceable.Slice(0, delim - " by".Length);
                var secondDelim = sliceable.LastIndexOf('=');
                arg0 = int.Parse(sliceable.Slice(secondDelim+1));
            }

            return (op, arg0, arg1);
        }

        private enum Operation
        {
            Rect,
            ShiftVertical,
            ShiftHorizontal
        }
    }
}

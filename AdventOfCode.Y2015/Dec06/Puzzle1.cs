
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
                    for (var x = op.Start.X; x <= op.End.X; x++)
                    {
                        switch(op.Action)
                        {
                            case Action.On:
                                grid[y * Rows + x] = true;
                                break;
                            case Action.Off:
                                grid[y * Rows + x] = false;
                                break;
                            case Action.Toggle:
                                grid[y * Rows + x] = !grid[y * Rows + x];
                                break;
                        }
                    }
                }
            }

            var count = 0;
            for (var i = 0; i < grid.Length; i++)
                if (grid[i])
                    count++;

            return count;
        }

        

        ref struct Operation
        {
            public Coords Start { get; init; }
            public Coords End { get; init; }
            public Action Action { get; init; }

            public static Operation Parse(ReadOnlySpan<char> line)
            {
                Action action = default;
                var map = new Dictionary<string, Action>()
                {
                    { "turn off", Action.Off },
                    { "turn on", Action.On},
                    { "toggle", Action.Toggle },
                };

                foreach (var item in map)
                {
                    if (line.StartsWith(item.Key))
                    {
                        action = item.Value;
                        line = line.Slice(item.Key.Length + 1);
                        break;
                    }
                }

                var idx = line.IndexOf(' ');
                var start = Coords.Parse(line.Slice(0, idx));
                var end = Coords.Parse(line.Slice(idx + " through ".Length));

                return new Operation()
                {
                    Start = start,
                    End = end,
                    Action = action
                };
            }
        }

        ref struct Coords
        {
            public int X { get; init; }
            public int Y { get; init; }

            public static Coords Parse(ReadOnlySpan<char> line)
            {
                var comma = line.IndexOf(',');
                var x = int.Parse(line.Slice(0, comma));
                var y = int.Parse(line.Slice(comma + 1));

                return new Coords()
                {
                    X = x,
                    Y = y,
                };
            }
        }

        enum Action
        {
            On,
            Off,
            Toggle
        }
    }
}

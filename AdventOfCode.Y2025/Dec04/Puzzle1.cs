using System.Diagnostics;

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

        public record Grid
        {
            private readonly bool[][] _data;
            public int Width { get; }
            public int Height { get; }

            private Grid(bool[][] data)
            {
                _data = data;
                Width = data[0].Length - 2;
                Height = data.Length - 2;
            }

            public bool GetCell(int x, int y)
            {
                return _data[y + 1][x + 1];
            }

            public bool this[int x, int y] => GetCell(x, y);

            public int CountNeighbors(int x, int y)
            {
                Debug.Assert(x >= 0 && x <= Width);
                Debug.Assert(y >= 0 && y <= Height);

                var count = 0;
                for (var dy = -1; dy <= 1; dy++)
                {
                    for (var dx = -1; dx <= 1; dx++)
                    {
                        if (dx == 0 && dy == 0)
                        {
                            continue;
                        }

                        if (GetCell(x + dx, y + dy))
                        {
                            count++;
                        }
                    }
                }

                return count;
            }

            public static Grid BuildGrid(IEnumerable<string> lines)
            {
                var enumerator = lines.GetEnumerator();
                if (!enumerator.MoveNext())
                {
                    throw new ArgumentException($"{nameof(lines)} can not be empty", nameof(lines));
                }

                // Build a buffer around the grid of all 'off' cells to simplify neighbor calculations
                var width = enumerator.Current.Length + 2;

                var grid = new List<bool[]>()
                {
                    new bool[width]
                };

                do
                {
                    var line = enumerator.Current;

                    var row = new bool[width];
                    for (var i = 0; i < line.Length; i++)
                    {
                        row[i + 1] = line[i] == '@';
                    }
                    grid.Add(row);
                } while (enumerator.MoveNext());

                grid.Add(new bool[width]);


                return new Grid([.. grid]);
            }
        }
    }
}

using System.Diagnostics;

namespace AdventOfCode.Y2025.Dec04
{
    public record Grid
    {
        private readonly bool[][] _data;
        public int Width { get; }
        public int Height { get; }

        private int ActualWidth { get; }
        private int ActualHeight { get; }

        private Grid(bool[][] data)
        {
            _data = data;

            Width = data[0].Length - 2;
            Height = data.Length - 2;

            ActualWidth = data[0].Length;
            ActualHeight = data.Length;
        }

        public bool this[int x, int y]
        {
            get => _data[y + 1][x + 1];
            set => _data[y + 1][x + 1] = value;
        }

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

                    if (this[x + dx, y + dy])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public Grid DeepClone()
        {
            var newData = new bool[ActualHeight][];

            for (var y = 0; y < ActualHeight; y++)
            {
                newData[y] = new bool[ActualWidth];
                Array.Copy(_data[y], newData[y], ActualWidth);
            }

            return new Grid(newData);
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

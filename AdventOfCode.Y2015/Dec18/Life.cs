namespace AdventOfCode.Y2015.Dec18
{
    public readonly struct LifeGeneration
    {
        public readonly int N { get; init; }
        public readonly bool[][] Data { get; init; }
    }

    public class Life
    {
        public LifeGeneration CurrentGeneration { get; private set; }

        public int Width { get; }
        public int Height { get; }

        public Life(bool[][] data)
        {
            Height = data.Length;
            Width = data.Length > 0 ? data[0].Length : 0;

            CurrentGeneration = new LifeGeneration()
            {
                N = 0,
                Data = data
            };
        }

        public void Render()
        {
            const char DEAD_CELL = '.';
            const char LIVE_CELL = '#';

            var maxDenizens = (int)Math.Floor(Math.Log10(Width * Height))+1;

            Console.SetCursorPosition(0, 1);

            Console.WriteLine($"Generation: {CurrentGeneration.N}");
            Console.WriteLine($"Count: {CountLivingDenizens().ToString().PadRight(maxDenizens)}");

            Console.Write('/');
            for (var i = 0; i < Width; i++)
                Console.Write('-');
            Console.WriteLine('\\');

            foreach (var row in CurrentGeneration.Data)
            {
                Console.Write('|');

                foreach (var col in row)
                    Console.Write(col ? LIVE_CELL : DEAD_CELL);

                Console.WriteLine('|');
            }

            Console.Write('\\');
            for (var i = 0; i < Width; i++)
                Console.Write('-');
            Console.WriteLine('/');
        }

        public void Evolve()
        {
            var currentGen = CurrentGeneration.Data;
            bool[][] nextGen = GC.AllocateUninitializedArray<bool[]>(currentGen.Length);

            for (var x = 0; x < nextGen.Length; x++)
            {
                nextGen[x] = GC.AllocateUninitializedArray<bool>(currentGen[x].Length);

                for (var y = 0; y < nextGen[x].Length; y++)
                {
                    var liveNeighbours = CountLiveNeighbours(currentGen, x, y);
                    if (currentGen[x][y])
                        nextGen[x][y] = (liveNeighbours == 2 || liveNeighbours == 3);
                    else
                        nextGen[x][y] = (liveNeighbours == 3);
                }
            }

            CurrentGeneration = new LifeGeneration()
            {
                N = CurrentGeneration.N + 1,
                Data = nextGen
            };
        }

        public long CountLivingDenizens()
        {
            var count = 0L;
            var data = CurrentGeneration.Data;

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static int CountLiveNeighbours(bool[][] data, int x, int y)
        {
            var count = 0;

            for (var xCount = Math.Max(x - 1, 0); xCount <= Math.Min(x + 1, data.Length - 1); xCount++)
            {
                for (var yCount = Math.Max(y - 1, 0); yCount <= Math.Min(y + 1, data[xCount].Length - 1); yCount++)
                {
                    if (data[xCount][yCount] && (xCount != x || yCount != y))
                        count++;
                }
            }

            return count;
        }

        public static Life Parse(IEnumerable<string> lines)
        {
            var data = new List<bool[]>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    throw new InvalidOperationException("Input file contained empty line");
                data.Add(Parse(line));
            }

            if (data.Count > 0)
            {
                var firstLen = data[0].Length;
                for (var i = 1; i < data.Count; i++)
                {
                    if (data[i].Length != firstLen)
                        throw new InvalidOperationException("Input file contained varying lengths");
                }
            }

            return new Life( [.. data]);

            static bool[] Parse(string line)
            {
                if (string.IsNullOrEmpty(line))
                    return [];
                else
                {
                    var result = GC.AllocateUninitializedArray<bool>(line.Length);

                    for (var i = 0; i < line.Length; i++)
                        result[i] = line[i] != '.';

                    return result;
                }
            }
        }
    }
}

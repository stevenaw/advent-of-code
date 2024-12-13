namespace AdventOfCode.Y2017.Dec10
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int BUFFER_SIZE = 256;

            var buffer = Enumerable.Range(0, BUFFER_SIZE).ToArray();
            var lengths = lines.First().Split(',').Select(int.Parse).ToArray();

            var skipSize = 0;
            var pos = 0;

            foreach (var length in lengths)
            {
                for (var i = 0; i < Math.Ceiling(length / 2d); i++)
                {
                    var x = (pos + i) % buffer.Length;
                    var y = (pos + (length-i-1)) % buffer.Length;

                    Swap(buffer, x, y);
                }

                pos = (pos + length + skipSize) % buffer.Length;
                skipSize++;
            }

            return buffer[0] * buffer[1];

            static void Swap(int[] buffer, int x, int y)
            {
                if (x != y)
                {
                    var tmp = buffer[x];
                    buffer[x] = buffer[y];
                    buffer[y] = tmp;
                }
            }
        }
    }
}

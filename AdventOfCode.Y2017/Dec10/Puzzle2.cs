using System.Text;

namespace AdventOfCode.Y2017.Dec10
{
    internal class Puzzle2 : AdventPuzzle<string>
    {
        static readonly byte[] suffix = [17, 31, 73, 47, 23];

        protected override string Solve(IEnumerable<string> lines)
        {
            const int BUFFER_SIZE = 256;
            const int ROUNDS = 64;
            const int BLOCK_SIZE = 16;

            var buffer = Enumerable.Range(0, BUFFER_SIZE).Select(x => (byte)x).ToArray();
            var lengths = Encoding.ASCII.GetBytes(lines.FirstOrDefault() ?? "").Concat(suffix).ToArray();

            var skipSize = 0;
            var pos = 0;

            for (var k = 0; k < ROUNDS; k++)
            {
                foreach (var length in lengths)
                {
                    for (var i = 0; i < Math.Ceiling(length / 2d); i++)
                    {
                        var x = (pos + i) % buffer.Length;
                        var y = (pos + (length - i - 1)) % buffer.Length;

                        Swap(buffer, x, y);
                    }

                    pos = (pos + length + skipSize) % buffer.Length;
                    skipSize++;
                }
            }

            var denseHash = new byte[BUFFER_SIZE / BLOCK_SIZE];
            for (var i = 0; i< denseHash.Length; i++)
            {
                byte value = 0;

                for (var j = 0; j < BLOCK_SIZE; j++)
                {
                    value ^= buffer[i * BLOCK_SIZE + j];
                }

                denseHash[i] = value;
            }

            var result = Convert.ToHexString(denseHash).ToLower();
            return result;

            static void Swap<T>(T[] buffer, int x, int y) where T : unmanaged
            {
                if (!x.Equals(y))
                {
                    var tmp = buffer[x];
                    buffer[x] = buffer[y];
                    buffer[y] = tmp;
                }
            }
        }
    }
}

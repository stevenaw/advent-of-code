using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2015.Dec04
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var line = lines.First();
            Span<char> buffer = stackalloc char[line.Length + 10];

            var suffix = buffer.Slice(line.Length);
            var prefix = buffer.Slice(0, line.Length);
            line.CopyTo(prefix);

            Span<byte> hash = stackalloc byte[16];

            for (var i = 0; i < int.MaxValue; i++)
            {
                if (i.TryFormat(suffix, out var len))
                {
                    var seed = buffer.Slice(0, line.Length + len);
                    var bytes = Encoding.Default.GetBytes(seed.ToString());

                    MD5.HashData(bytes, hash);

                    var str = Convert.ToHexString(hash);

                    if (str.StartsWith("00000"))
                        return i;
                }
            }

            return 0;
        }
    }
}

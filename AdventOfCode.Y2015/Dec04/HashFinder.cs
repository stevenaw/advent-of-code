using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2015.Dec04
{
    internal class HashFinder
    {
        private readonly string _seed;

        public HashFinder(string seed)
        {
            _seed = seed;
        }

        public int GetHashStartsWith(string startsWith)
        {
            Span<char> buffer = stackalloc char[_seed.Length + 10];

            var suffix = buffer.Slice(_seed.Length);
            var prefix = buffer.Slice(0, _seed.Length);
            _seed.CopyTo(prefix);

            Span<byte> hash = stackalloc byte[16];

            for (var i = 0; i < int.MaxValue; i++)
            {
                if (i.TryFormat(suffix, out var len))
                {
                    var seed = buffer.Slice(0, _seed.Length + len);
                    var bytes = Encoding.Default.GetBytes(seed.ToString());

                    MD5.HashData(bytes, hash);

                    var str = Convert.ToHexString(hash);

                    if (str.StartsWith(startsWith))
                        return i;
                }
            }

            return -1;
        }
    }
}

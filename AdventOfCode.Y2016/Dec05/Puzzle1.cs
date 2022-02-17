using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2016.Dec05
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int DigitCount = 8;

            Span<char> password = stackalloc char[DigitCount];

            var payloadPrefix = lines.First();
            var suffixIdx = 0;

            for (var i = 0; i < DigitCount; i++)
            {
                string hash;

                while (!(hash = Hasher.HashAsHexString(payloadPrefix, suffixIdx++)).StartsWith("00000"))
                { }

                password[i] = hash[5];
            }

            return TypeEncoder.EncodeAsLong(password);
        }
    }
}

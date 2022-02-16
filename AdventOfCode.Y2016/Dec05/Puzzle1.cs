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
            var suffixIdx = -1;

            for (var i = 0; i < DigitCount; i++)
            {
                string hash;

                do
                {
                    suffixIdx++;

                    var payload = payloadPrefix + suffixIdx.ToString();
                    var stringBytes = Encoding.Default.GetBytes(payload.ToString());
                    var hashBytes = MD5.HashData(stringBytes);

                    hash = Convert.ToHexString(hashBytes);
                } while (!hash.StartsWith("00000"));

                password[i] = hash[5];
            }

            return TypeEncoder.EncodeAsLong(password.ToString());
        }
    }
}

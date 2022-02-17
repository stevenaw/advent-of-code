using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2016.Dec05
{
    internal static class Hasher
    {
        public static string HashAsHexString(string prefix, int suffix)
        {
            Span<char> payload = stackalloc char[prefix.Length + 10];
            prefix.CopyTo(payload.Slice(0, prefix.Length));
            suffix.TryFormat(payload.Slice(prefix.Length), out var len);

            var trimmedPayload = payload.Slice(0, prefix.Length + len);

            Span<byte> payloadBytes = stackalloc byte[trimmedPayload.Length * sizeof(char)];
            var size = Encoding.Default.GetBytes(trimmedPayload, payloadBytes);
            payloadBytes = payloadBytes.Slice(0, size);

            Span<byte> hashBytes = stackalloc byte[16];
            MD5.HashData(payloadBytes, hashBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}

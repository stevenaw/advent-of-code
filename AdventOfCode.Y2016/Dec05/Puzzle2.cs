namespace AdventOfCode.Y2016.Dec05
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            Span<char> password = stackalloc char[8];

            var payloadPrefix = lines.First();
            var suffixIdx = 0;
            var neededDigits = byte.MaxValue;

            while (neededDigits != 0)
            {
                string hash;
                while (!(hash = Hasher.HashAsHexString(payloadPrefix, suffixIdx++)).StartsWith("00000"))
                { }

                var pos = (int)(hash[5] - '0');
                if ((neededDigits & (1UL << pos)) != 0)
                {
                    neededDigits &= (byte)~(1UL << pos);
                    password[pos] = hash[6];
                }
            }

            return TypeEncoder.EncodeAsLong(password);
        }
    }
}

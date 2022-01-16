namespace AdventOfCode.Y2015.Dec11
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First();

            var result = PasswordGenerator.GenerateNextPasswords(input, 1);

            Console.WriteLine(result[0]);

            return EncodeAsLong(result[0]);
        }

        private static long EncodeAsLong(string s)
        {
            var result = 0L;
            var idx = s.Length;

            foreach(var c in s)
                result |= ((byte)c) << (--idx*8);

            return result;
        }
    }
}

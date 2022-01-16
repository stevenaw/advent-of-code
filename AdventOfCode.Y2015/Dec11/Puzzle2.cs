namespace AdventOfCode.Y2015.Dec11
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First();

            var result = PasswordGenerator.GenerateNextPasswords(input, 2);

            Console.WriteLine(result.Last());

            return TypeEncoder.EncodeAsLong(result.Last());
        }
    }
}

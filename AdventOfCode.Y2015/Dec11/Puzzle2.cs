namespace AdventOfCode.Y2015.Dec11
{
    internal class Puzzle2 : AdventPuzzle<string>
    {
        protected override string Solve(IEnumerable<string> lines)
        {
            var input = lines.First();

            var result = PasswordGenerator.GenerateNthPassword(input, 2);

            return result;
        }
    }
}

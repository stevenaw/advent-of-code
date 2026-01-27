namespace AdventOfCode.Y2018.Dec01
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;

            foreach (var line in lines)
            {
                if (line[0] == '+')
                {
                    sum += long.Parse(line[1..]);
                }
                else
                {
                    sum -= long.Parse(line[1..]);
                }
            }

            return sum;
        }
    }
}

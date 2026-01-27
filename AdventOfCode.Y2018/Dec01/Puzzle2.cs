namespace AdventOfCode.Y2018.Dec01
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;
            var frequencies = new HashSet<long> { };


            var ops = lines.ToList();

            while (true)
            {
                foreach (var line in ops)
                {
                    if (line[0] == '+')
                    {
                        sum += long.Parse(line[1..]);
                    }
                    else
                    {
                        sum -= long.Parse(line[1..]);
                    }

                    if (!frequencies.Add(sum))
                    {
                        return sum;
                    }
                }
            }
        }
    }
}

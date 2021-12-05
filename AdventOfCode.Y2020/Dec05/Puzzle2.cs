namespace AdventOfCode.Y2020.Dec05
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {

            Span<bool> seats = stackalloc bool[1024];

            foreach (var line in lines)
            {
                var idx = BinaryTranslator.CalculateIndex(line);
                seats[idx] = true;
            }

            for (var i = 32; i < seats.Length - 32; i++)
                if (!seats[i])
                    return i;

            return 0;
        }
    }
}

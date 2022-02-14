namespace AdventOfCode.Y2016.Dec04
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0;

            foreach (var line in lines)
            {
                var item = InputParser.Parse(line);
                if (item.IsValid())
                    sum += item.SectorId;
            }

            return sum;
        }
    }
}

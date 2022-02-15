namespace AdventOfCode.Y2016.Dec04
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0;

            foreach (var line in lines)
            {
                var item = InputRecord.Parse(line);
                if (item.IsValid())
                {
                    var realName = item.Decrypt();
                    if (realName.Contains("north", StringComparison.Ordinal))
                        return item.SectorId;
                }
            }

            return sum;
        }
    }
}

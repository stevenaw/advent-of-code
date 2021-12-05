namespace AdventOfCode.Y2020.Dec07
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var contained = BagHelper.ParseContainedBags(lines);
            var count = BagHelper.CountContainedBags(contained, "shiny gold");

            return count;
        }
    }
}

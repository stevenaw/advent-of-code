namespace AdventOfCode.Y2020.Dec07
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var containedBy = BagHelper.ParseBagsContainedBy(lines);
            var bags = BagHelper.GetContainingBagTypes(containedBy, "shiny gold");

            return bags.Distinct().Count();
        }
    }
}

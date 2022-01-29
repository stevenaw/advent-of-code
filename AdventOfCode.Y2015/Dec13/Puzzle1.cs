namespace AdventOfCode.Y2015.Dec13
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var neighbours = Neighbour.ParseMany(lines);
            var optimalHappiness = SeatingOptimizer.CalculateOptimalHappiness(neighbours);

            return optimalHappiness;
        }
    }
}

namespace AdventOfCode.Y2015.Dec13
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var weights = Neighbour.ParseMany(lines).ToList();
            var distinctNames = weights.Select(o => o.PersonA)
                .Union(weights.Select(o => o.PersonB))
                .Distinct()
                .ToArray();

            foreach(var name in distinctNames)
                weights.Add(new Neighbour(name, "Myself", 0));

            var optimalHappiness = SeatingOptimizer.CalculateOptimalHappiness(weights.ToArray());

            return optimalHappiness;
        }
    }
}

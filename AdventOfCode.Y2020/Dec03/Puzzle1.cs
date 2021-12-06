namespace AdventOfCode.Y2020.Dec03
{
    public class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var trees = TreeParser.ParseTrees(lines);
            var result = RayTracer.CountObstacles(trees, 3, 1);

            return result;
        }
    }
}

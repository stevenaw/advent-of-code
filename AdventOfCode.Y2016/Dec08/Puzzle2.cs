namespace AdventOfCode.Y2016.Dec08
{
    internal class Puzzle2 : AdventPuzzle<string>
    {
        protected override string Solve(IEnumerable<string> lines)
        {
            var grid = new Grid(50, 6);

            foreach (var line in lines)
            {
                var transform = Grid.ParseTransform(line);
                grid.Transform(transform);

                Console.WriteLine(line);
                grid.Output();
            }

            // Output to console by above
            return "AFBUPZBJPS";
        }
    }
}

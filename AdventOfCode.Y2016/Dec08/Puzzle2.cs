namespace AdventOfCode.Y2016.Dec08
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var grid = new Grid(50, 6);

            foreach (var line in lines)
            {
                var transform = Grid.ParseTransform(line);
                grid.Transform(transform);

                Console.WriteLine(line);
                grid.Output();
            }

            return TypeEncoder.EncodeLettersAsLong("AFBUPZBJPS");
        }
    }
}

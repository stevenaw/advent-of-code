namespace AdventOfCode.Y2016.Dec01
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var headingIdx = 0;
            Span<(int deltaX, int deltaY)> movements = stackalloc (int, int)[] {
                (0, 1),
                (1, 0),
                (0, -1),
                (-1, 0)
            };
            var coords = (x: 0, y: 0);
            var visited = new HashSet<(int, int)>()
            {
                coords
            };

            foreach (var command in InputParser.ParseCommands(lines.First()))
            {
                var delta = command.Direction == 'R' ? 1 : -1;

                headingIdx = ((headingIdx + delta) + movements.Length) % movements.Length;

                ref var change = ref movements[headingIdx];

                for (var i = 0; i < command.Distance; i++)
                {
                    coords = (x: coords.x + change.deltaX, y: coords.y + change.deltaY);
                    if (!visited.Add(coords))
                        goto done; // welp
                }
            }

done:
            return Math.Abs(coords.x) + Math.Abs(coords.y);
        }
    }
}

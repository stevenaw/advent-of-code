namespace AdventOfCode.Y2015.Dec03
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var line = lines.First();

            var visits = new HashSet<Coordinate>();
            var coords = new Coordinate[2];

            coords[0] = new Coordinate();
            coords[1] = new Coordinate();

            visits.Add(coords[0]);

            for (var i = 0; i < line.Length; i++)
            {
                ref var coord = ref coords[i % 2];

                coord = coord.Translate(line[i]);
                visits.Add(coord);
            }

            return visits.Count;
        }
    }
}

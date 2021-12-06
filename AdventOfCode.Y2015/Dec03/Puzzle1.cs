namespace AdventOfCode.Y2015.Dec03
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var line = lines.First();

            var visits = new HashSet<Coordinate>();
            var coord = new Coordinate();

            visits.Add(coord);

            foreach (var move in line)
            {
                coord = coord.Translate(move);
                visits.Add(coord);
            }

            return visits.Count;
        }
    }
}

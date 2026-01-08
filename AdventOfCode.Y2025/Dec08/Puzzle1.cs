namespace AdventOfCode.Y2025.Dec08
{
    internal class Puzzle1 : AdventPuzzle
    {
        const int NodeCount = 1000;

        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = lines.Select(Point.Parse).ToArray();

            // Find distance to each other point
            var edges = PuzzleHelpers.FindEdges(nodes);
            edges.Sort((x, y) => (int)(x.distance - y.distance));

            var edgeIdx = 0;
            var connections = new List<HashSet<Point>>();

            for (var i = 0; i < NodeCount; i++)
            {
                // Dequeue the next and connect it
                PuzzleHelpers.Connect(connections, edges[edgeIdx++]);
            }

            connections.Sort((a, b) => b.Count - a.Count);

            long amt = 1;
            for (var i = 0; i < 3; i++)
            {
                amt *= connections[i].Count;
            }

            return amt;

        }
    }
}

namespace AdventOfCode.Y2025.Dec08
{
    internal class Puzzle1 : AdventPuzzle
    {
        const int nodeCount = 1000;

        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = lines.Select(Point.Parse).ToArray();

            // Find distance to each other point
            var edges = FindEdges(nodes);
            edges.Sort((x, y) => (int)(x.distance - y.distance));

            var edgeIdx = 0;
            var connections = new List<HashSet<Point>>();

            for (var i = 0; i < nodeCount; i++)
            {
                // Dequeue the next
                var next = edges[edgeIdx++];

                HashSet<Point> ca = null;
                foreach(var c in connections)
                {
                    if (c.Contains(next.a))
                    {
                        ca = c;
                        break;
                    }
                }

                HashSet<Point> cb = null;
                foreach (var c in connections)
                {
                    if (c.Contains(next.b))
                    {
                        cb = c;
                        break;
                    }
                }

                if (ca is null && cb is null)
                {
                    // Neither exists, so make a new connection
                    connections.Add([next.a, next.b]);
                }
                else if (Object.ReferenceEquals(ca, cb))
                {
                    // Both exist in same circuit. Do nothing
                }
                else if (ca is not null && cb is not null)
                {
                    // Both exist in different circuits. Connect them
                    ca.UnionWith(cb);
                    connections.Remove(cb);
                }
                else
                {
                    // One exists in a circuit and one does not. Find which and add it
                    var c = ca ?? cb!;
                    c.Add(next.a);
                    c.Add(next.b);
                }
            }

            connections.Sort((a, b) => b.Count - a.Count);

            long amt = 1;
            for (var i = 0; i < 3; i++)
            {
                amt *= connections[i].Count;
            }

            return amt;

        }

        private static List<Edge> FindEdges(Point[] points)
        {
            ArgumentNullException.ThrowIfNull(points);

            var n = points.Length;
            var result = new List<Edge>();

            for (var i = 0; i < n; i++)
            {
                var pi = points[i];

                for (var j = i + 1; j < n; j++)
                {
                    var pj = points[j];
                    var dx = (double)pi.X - pj.X;
                    var dy = (double)pi.Y - pj.Y;
                    var dz = (double)pi.Z - pj.Z;
                    var dist = (double)Math.Sqrt(dx * dx + dy * dy + dz * dz);

                    result.Add(new (pi, pj, dist));
                }
            }

            return result;
        }

        private record Edge(Point a, Point b, double distance);

        private record Point(int X, int Y, int Z)
        {
            public static Point Parse(string line)
            {
                var points = line.Split(',');

                return new Point(
                    int.Parse(points[0]),
                    int.Parse(points[1]),
                    int.Parse(points[2])
                );
            }
        }
    }
}

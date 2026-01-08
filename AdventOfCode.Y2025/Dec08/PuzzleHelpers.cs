namespace AdventOfCode.Y2025.Dec08
{
    internal class PuzzleHelpers
    {
        internal static Edge[] FindEdges(Point[] points)
        {
            ArgumentNullException.ThrowIfNull(points);

            var n = points.Length;
            var result = GC.AllocateUninitializedArray<Edge>(n * (n/2) - n/2);
            var count = 0;

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

                    result[count++] = new(pi, pj, dist);
                }
            }

            return result;
        }

        internal static void Connect(List<HashSet<Point>> connections, Edge edge)
        {
            HashSet<Point> ca = null;
            foreach (var c in connections)
            {
                if (c.Contains(edge.a))
                {
                    ca = c;
                    break;
                }
            }

            HashSet<Point> cb = null;
            foreach (var c in connections)
            {
                if (c.Contains(edge.b))
                {
                    cb = c;
                    break;
                }
            }

            if (ca is null && cb is null)
            {
                // Neither exists, so make a new connection
                connections.Add([edge.a, edge.b]);
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
                c.Add(edge.a);
                c.Add(edge.b);
            }
        }
    }

    internal record Edge(Point a, Point b, double distance);

    internal record Point(int X, int Y, int Z)
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

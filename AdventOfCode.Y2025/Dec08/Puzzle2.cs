using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Y2025.Dec08
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = lines.Select(Point.Parse).ToArray();

            // Find distance to each other point
            var edges = PuzzleHelpers.FindEdges(nodes);
            edges.Sort((x, y) => (int)(x.distance - y.distance));

            var connections = new List<HashSet<Point>>();
            var edgeIdx = 0;
            Edge last;

            do
            {
                // Dequeue the next and connect it
                last = edges[edgeIdx++];
                PuzzleHelpers.Connect(connections, last);
            } while (!(connections.Count == 1 && connections[0].Count == nodes.Length));

            return last.a.X * last.b.X;
        }
    }
}

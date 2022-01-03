using System.Diagnostics;

namespace AdventOfCode.Y2015.Dec09
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = ParseNodes(lines);
            var shortestDistance = int.MaxValue;

            foreach (var start in nodes)
            {
                var dist = ShortestPathToVisitAll(start, new List<Node>());
                shortestDistance = Math.Min(shortestDistance, dist);
            }
                
            return shortestDistance;
        }

        private static int ShortestPathToVisitAll(Node start, List<Node> visited)
        {
            visited.Add(start);

            var shortest = int.MaxValue;

            foreach(var next in start.Distances)
            {
                if (!visited.Contains(next.Key))
                {
                    var dist = next.Value + ShortestPathToVisitAll(next.Key, visited);
                    shortest = Math.Min(shortest, dist);
                }
            }

            visited.Remove(start);

            if (shortest == int.MaxValue)
                return 0;

            return shortest;
        }

        private static Node[] ParseNodes(IEnumerable<string> lines)
        {
            var nodes = new Dictionary<string, Node>();

            foreach(var line in lines)
            {
                var tokens = line.Split(' ');

                var from = tokens[0];
                var to = tokens[2];
                var distance = int.Parse(tokens[4].Trim());

                if (!nodes.TryGetValue(from, out var fromNode))
                    nodes[from] = fromNode = new Node(from);

                if (!nodes.TryGetValue(to, out var toNode))
                    nodes[to] = toNode = new Node(to);

                fromNode.Distances.Add(toNode, distance);
                toNode.Distances.Add(fromNode, distance);
            }

            return nodes.Values.ToArray();
        }
    }

    [DebuggerDisplay("{Name}")]
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Distances { get; set; } = new Dictionary<Node, int>();

        public Node(string name)
        {
            Name = name;
        }
    }
}

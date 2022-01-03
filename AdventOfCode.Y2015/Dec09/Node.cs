using System.Diagnostics;

namespace AdventOfCode.Y2015.Dec09
{
    [DebuggerDisplay("{Name}")]
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Distances { get; set; } = new Dictionary<Node, int>();

        public Node(string name)
        {
            Name = name;
        }

        public static Node[] ParseMany(IEnumerable<string> lines)
        {
            var nodes = new Dictionary<string, Node>();

            foreach (var line in lines)
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
}

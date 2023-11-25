using System.Runtime.InteropServices;

namespace AdventOfCode.Y2017.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = new Dictionary<string, Node>();

            foreach (var line in lines)
            {
                var node = Node.Parse(line);
                nodes[node.Name] = node;
            }

            foreach(var nodeName in nodes.Keys)
            {
                var found = nodes.Values.Any(x => x.Children.Contains(nodeName));

                if (!found)
                {
                    Console.WriteLine($"Root Node: {nodeName}");
                    return TypeEncoder.EncodeLettersAsLong(nodeName);
                }
            }

            return 0;
        }

        private record Node(string Name, int Weight, List<string> Children)
        {
            public static Node Parse(string line)
            {
                var items = line.Split(' ');

                var name = items[0];
                var weight = int.Parse(items[1].AsSpan()[1..^1]);
                var children = new List<string>();

                for (var i = 3; i < items.Length; i++)
                {
                    children.Add(items[i].Trim(','));
                }

                return new Node(name, weight, children);
            }
        }
    }
}

using System.Runtime.InteropServices;

namespace AdventOfCode.Y2017.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = lines.Select(Node.Parse).ToDictionary(o => o.Name);

            foreach(var nodeName in nodes.Keys)
            {
                var found = nodes.Values.Any(x => x.Children.Contains(nodeName));

                if (!found)
                {
                    Console.WriteLine($"Root Node: {nodeName}");
                    return TypeEncoder.EncodeLettersAsLong(nodeName);
                }
            }

            throw new InvalidOperationException("The answer couldn't be found.");
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

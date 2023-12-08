namespace AdventOfCode.Y2017.Dec07
{
    internal record Node(string Name, int Weight, List<Node> Children)
    {
        public static Node ParseTree(IEnumerable<string> lines)
        {
            // TODO: This could be better as parallel arrays
            var rootCandidates = new List<Node>();
            var nodes = new List<Node>();
            var allNodes = new Dictionary<string, Node>();
            var allChildren = new Dictionary<string, List<string>>();

            foreach (var line in lines)
            {
                var items = line.Split(' ');

                var name = items[0];
                var weight = int.Parse(items[1].AsSpan()[1..^1]);

                var children = new List<string>();
                for (var i = 3; i < items.Length; i++)
                    children.Add(items[i].Trim(','));


                var node = new Node(name, weight, new List<Node>());

                nodes.Add(node);
                allNodes.Add(node.Name, node);
                allChildren.Add(node.Name, children);
                rootCandidates.Add(node);
            }

            foreach(var node in nodes)
            {
                foreach (var childName in allChildren[node.Name])
                {
                    var child = allNodes[childName];

                    node.Children.Add(child);
                    rootCandidates.Remove(child);
                }
            }
            
            return rootCandidates[0];
        }
    }
}

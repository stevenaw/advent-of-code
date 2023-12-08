namespace AdventOfCode.Y2017.Dec07
{
    internal record TreeNode(string Name, int Weight, List<TreeNode> Children);

    internal readonly ref struct Tree
    {
        public TreeNode Root { get; init; }
        public List<TreeNode> AllNodes { get; init; }

        public static Tree Parse(IEnumerable<string> lines)
        {
            var rootCandidates = new List<TreeNode>();
            var nodes = new List<TreeNode>();
            // TODO: This could be better as parallel arrays
            var allNodes = new Dictionary<string, TreeNode>();
            var allChildren = new Dictionary<string, List<string>>();

            foreach (var line in lines)
            {
                var items = line.Split(' ');

                var name = items[0];
                var weight = int.Parse(items[1].AsSpan()[1..^1]);

                var children = new List<string>();
                for (var i = 3; i < items.Length; i++)
                    children.Add(items[i].Trim(','));


                var node = new TreeNode(name, weight, new());

                nodes.Add(node);
                allNodes.Add(node.Name, node);
                allChildren.Add(node.Name, children);
                rootCandidates.Add(node);
            }

            foreach (var node in nodes)
            {
                foreach (var childName in allChildren[node.Name])
                {
                    var child = allNodes[childName];

                    node.Children.Add(child);
                    rootCandidates.Remove(child);
                }
            }

            return new Tree
            {
                Root = rootCandidates[0],
                AllNodes = nodes
            };
        }
    }
}

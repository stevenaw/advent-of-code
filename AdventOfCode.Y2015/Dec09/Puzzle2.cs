namespace AdventOfCode.Y2015.Dec09
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = Node.ParseMany(lines);
            var longest = 0;

            foreach (var start in nodes)
            {
                var dist = LongestPathToVisitAll(start, new List<Node>());
                longest = Math.Max(longest, dist);
            }

            return longest;
        }

        private static int LongestPathToVisitAll(Node start, List<Node> visited)
        {
            visited.Add(start);

            var longest = 0;

            foreach (var next in start.Distances)
            {
                if (!visited.Contains(next.Key))
                {
                    var dist = next.Value + LongestPathToVisitAll(next.Key, visited);
                    longest = Math.Max(longest, dist);
                }
            }

            visited.Remove(start);

            return longest;
        }
    }
}

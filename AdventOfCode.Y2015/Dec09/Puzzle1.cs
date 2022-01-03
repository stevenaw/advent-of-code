namespace AdventOfCode.Y2015.Dec09
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var nodes = Node.ParseMany(lines);
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
    }
}

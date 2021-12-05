namespace AdventOfCode.Y2020.Dec10
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var numbers = lines.Select(o => int.Parse(o)).OrderBy(o => o).ToList();

            numbers.Insert(0, 0);
            numbers.Add(numbers.Last() + 3);

            var map = new List<int>[numbers.Max() + 1];
            for (var i = 0; i < numbers.Count; i++)
            {
                var nextNodes = new List<int>(3);
                for (var j = i + 1; j < numbers.Count && numbers[j] - numbers[i] <= 3; j++)
                    nextNodes.Add(numbers[j]);

                map[numbers[i]] = nextNodes;
            }

            var knownPathCount = new long[map.Length];
            var totalPaths = CountPaths(map, numbers.First(), numbers.Last(), knownPathCount);

            return totalPaths;
        }

        private static long CountPaths(List<int>[] map, int current, int end, long[] knownPathCount)
        {
            if (current == end)
                return 1L;
            else if (knownPathCount[current] > 0)
                return knownPathCount[current];

            var nextNodes = map[current];
            var pathsFromHere = 0L;

            foreach (var nextNode in nextNodes)
            {
                var count = CountPaths(map, nextNode, end, knownPathCount);

                knownPathCount[nextNode] = count;

                pathsFromHere += count;
            }

            knownPathCount[current] = pathsFromHere;
            return pathsFromHere;
        }
    }
}

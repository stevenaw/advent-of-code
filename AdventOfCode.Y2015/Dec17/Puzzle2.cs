namespace AdventOfCode.Y2015.Dec17
{
    internal partial class Puzzle2 : AdventPuzzle
    {
        const int Total = 150;

        protected override long Solve(IEnumerable<string> lines)
        {
            var sizes = lines.Select(int.Parse).ToArray();

            var combos = EnumerateCombos(sizes).ToList();

            var minLength = combos.Min(x => x.Length);
            var count = combos.Where(x => x.Length == minLength).Count();

            return count;
        }

        private static IEnumerable<int[]> EnumerateCombos(int[] items)
        {
            Array.Sort(items);

            return EnumerateCombos(items, new Stack<int>(items.Length));

            static IEnumerable<int[]> EnumerateCombos(int[] items, Stack<int> combo)
            {
                var workingSet = new Stack<int>(items);

                while (workingSet.Count > 0)
                {
                    var next = workingSet.Pop();
                    combo.Push(next);
                    var sum = combo.Sum();

                    if (sum == Total)
                    {
                        yield return combo.ToArray();
                    }
                    else if (sum < Total)
                    {
                        foreach (var item in EnumerateCombos([.. workingSet], combo))
                            yield return item;
                    }

                    combo.Pop();
                }
            }
        }
    }
}

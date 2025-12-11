namespace AdventOfCode.Y2015.Dec17
{
    internal class Puzzle1 : AdventPuzzle
    {
        const int Total = 150;

        protected override long Solve(IEnumerable<string> lines)
        {
            var sizes = lines.Select(int.Parse).ToArray();

            return CountCombos(sizes);
        }

        private static int CountCombos(int[] items)
        {
            Array.Sort(items);

            return CountCombos(items, new Stack<int>(items.Length));

            static int CountCombos(int[] items, Stack<int> combo)
            {
                var count = 0;
                var workingSet = new Stack<int>(items);

                while (workingSet.Count > 0)
                {
                    var next = workingSet.Pop();
                    combo.Push(next);
                    var sum = combo.Sum();

                    if (sum == Total)
                    {
                        count++;
                    }
                    else if (sum < Total)
                    {
                        count += CountCombos([.. workingSet], combo);
                    }

                    combo.Pop();
                }

                return count;
            }
        }
    }
}

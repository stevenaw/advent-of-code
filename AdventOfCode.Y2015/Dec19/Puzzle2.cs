namespace AdventOfCode.Y2015.Dec19
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var (transforms, haystack) = PuzzleInput.Parse(lines);

            // TODO: First happens to be best here, but not guaranteed
            var steps = EnumerateStepsBackwards(haystack, "e", transforms).First();

            return steps;
        }

        private static IEnumerable<int> EnumerateStepsBackwards(string haystack, string end, Dictionary<string, List<string>> transforms, int steps = 0)
        {
            if (haystack == end)
            {
                yield return steps;
            }

            foreach (var kvp in transforms)
            {
                foreach (var from in kvp.Value)
                {
                    var to = kvp.Key;

                    if (to == end && haystack != from)
                    {
                        // can't reduce as we don't want to
                        // put end state in the middle of the string
                        continue;
                    }

                    var i = 0;
                    var idx = haystack.IndexOf(from, i, StringComparison.Ordinal);

                    while (idx != -1)
                    {
                        var candidate = haystack.ReplaceAt(from, to, idx);
                        foreach (var result in EnumerateStepsBackwards(candidate, end, transforms, steps + 1))
                        {
                            yield return result;
                        }

                        i = idx + 1;
                        idx = haystack.IndexOf(from, i, StringComparison.Ordinal);
                    }
                }
            }
        }
    }
}

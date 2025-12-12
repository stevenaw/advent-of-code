namespace AdventOfCode.Y2015.Dec19
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var (transforms, haystack) = PuzzleInput.Parse(lines);

            var distinctCount = EnumerateReplacements(haystack, transforms).Distinct().Count();

            return distinctCount;
        }

        private static IEnumerable<string> EnumerateReplacements(string haystack, Dictionary<string, List<string>> transforms)
        {
            foreach (var kvp in transforms)
            {
                var i = 0;
                var idx = haystack.IndexOf(kvp.Key, i, StringComparison.Ordinal);
                while (idx != -1)
                {
                    // we've found a token to substitute
                    foreach (var replacement in kvp.Value)
                    {
                        yield return haystack.ReplaceAt(kvp.Key, replacement, idx);
                    }

                    i = idx + 1;
                    idx = haystack.IndexOf(kvp.Key, i, StringComparison.Ordinal);
                }
            }

        }
    }
}

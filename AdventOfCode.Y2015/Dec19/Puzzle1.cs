namespace AdventOfCode.Y2015.Dec19
{
    internal partial class Puzzle1 : AdventPuzzle
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
                        var newLength = haystack.Length - kvp.Key.Length + replacement.Length;
                        var newString = string.Create(
                            newLength,
                            (haystack, needle: kvp.Key, replacement, idx),
                            (buffer, state) =>
                            {
                                var h = haystack.AsSpan();

                                h.Slice(0, idx).CopyTo(buffer);
                                replacement.AsSpan().CopyTo(buffer.Slice(idx));
                                h.Slice(idx + kvp.Key.Length).CopyTo(buffer.Slice(idx + replacement.Length));

                            });

                        yield return newString;
                    }

                    i = idx + 1;
                    idx = haystack.IndexOf(kvp.Key, i, StringComparison.Ordinal);
                }
            }
        }
    }
}

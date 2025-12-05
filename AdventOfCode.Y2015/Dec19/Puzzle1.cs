using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdventOfCode.Y2015.Dec19
{
    internal partial class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            Dictionary<string, List<string>> transforms = new Dictionary<string, List<string>>();
            var transformSpanLookup = transforms.GetAlternateLookup<ReadOnlySpan<char>>();

            var enumerator = lines.GetEnumerator();

            // Build mapping
            while (enumerator.MoveNext() && !string.IsNullOrEmpty(enumerator.Current))
            {
                var currentSpan = enumerator.Current.AsSpan();

                var idx = currentSpan.IndexOf(" => ");
                var needle = currentSpan.Slice(0, idx);
                var replacement = currentSpan.Slice(idx + " => ".Length);

                if (!transformSpanLookup.TryGetValue(needle, out var replacements))
                {
                    transformSpanLookup[needle] = replacements = new List<string>();
                }

                replacements.Add(replacement.ToString());
            }

            string haystack = string.Empty;
            if (enumerator.MoveNext())
            {
                haystack = enumerator.Current;
            }

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
                        var newString = haystack.Substring(0, idx) + replacement + haystack.Substring(idx + kvp.Key.Length);
                        yield return newString;
                    }

                    i = idx + 1;
                    idx = haystack.IndexOf(kvp.Key, i, StringComparison.Ordinal);
                }
            }
        }
    }
}

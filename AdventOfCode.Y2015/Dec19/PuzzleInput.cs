namespace AdventOfCode.Y2015.Dec19
{
    internal record struct PuzzleInput(Dictionary<string, List<string>> transforms, string haystack)
    {
        internal static PuzzleInput Parse(IEnumerable<string> lines)
        {
            const string TransformDelimiter = " => ";

            Dictionary<string, List<string>> transforms = new Dictionary<string, List<string>>();
            var transformSpanLookup = transforms.GetAlternateLookup<ReadOnlySpan<char>>();

            var enumerator = lines.GetEnumerator();

            // Build mapping
            while (enumerator.MoveNext() && !string.IsNullOrEmpty(enumerator.Current))
            {
                var currentSpan = enumerator.Current.AsSpan();

                var idx = currentSpan.IndexOf(TransformDelimiter, StringComparison.Ordinal);
                var needle = currentSpan.Slice(0, idx);
                var replacement = currentSpan.Slice(idx + TransformDelimiter.Length);

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

            return new PuzzleInput(transforms, haystack);
        }
    }
}

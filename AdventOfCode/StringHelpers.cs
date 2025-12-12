namespace AdventOfCode
{
    public static class StringHelpers
    {
        public static string ReplaceAt(this string haystack, string needle, string replacement, int index)
        {
            var newLength = haystack.Length - needle.Length + replacement.Length;
            var newString = string.Create(
                newLength,
                (haystack, needle, replacement, index),
                static (buffer, state) =>
                {
                    var (haystack, needle, replacement, index) = state;

                    var h = haystack.AsSpan();

                    h.Slice(0, index).CopyTo(buffer);

                    var dest = buffer.Slice(index);
                    replacement.AsSpan().CopyTo(dest);
                    h.Slice(index + needle.Length).CopyTo(buffer.Slice(index + replacement.Length));
                });

            return newString;
        }
    }
}

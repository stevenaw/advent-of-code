using System.Text;

namespace AdventOfCode.Y2016.Dec09
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var line = lines.First().AsSpan();
            var result = new StringBuilder();

            while (!line.IsEmpty)
            {
                var nextExpansion = line.IndexOf('(');
                if (nextExpansion == -1)
                {
                    result.Append(line);
                    line = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    if (nextExpansion != 0)
                    {
                        // eagerly process chars ahead of '('
                        result.Append(line.Slice(0, nextExpansion));
                        line = line.Slice(nextExpansion);
                    }

                    var processedLength = ProcessExpansion(line, out var expansion);
                    result.Append(expansion);
                    line = line.Slice(processedLength);
                }
            }

            return result.Length;
        }

        private static int ProcessExpansion(ReadOnlySpan<char> chars, out string expansion)
        {
            int processedCount = 0;
            var delim = chars.IndexOf('x');
            var lettersToExpand = int.Parse(chars[1..delim]);
            chars = chars.Slice(delim);
            processedCount += delim;

            delim = chars.IndexOf(')');
            var numberOfExpansions = int.Parse(chars[1..delim]);
            chars = chars.Slice(delim + 1);
            processedCount += delim + 1;

            var toExpand = chars.Slice(0, lettersToExpand);
            processedCount += lettersToExpand;

            expansion = String.Create(numberOfExpansions * toExpand.Length, toExpand.ToString(), (buffer, state) =>
            {
                var j = 0;
                for (var i = 0; i < numberOfExpansions; i++)
                {
                    state.CopyTo(buffer.Slice(j, state.Length));
                    j += state.Length;
                }
            });
            return processedCount;
        }
    }
}

using System.Text.Json;

namespace AdventOfCode.Y2015.Dec12
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First();
            var doc = JsonDocument.Parse(input);
            var sum = SumChildNumbers(doc.RootElement);
            
            return sum;

        }

        private static long SumChildNumbers(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                var level = 0L;
                foreach (var item in element.EnumerateArray())
                    level += SumChildNumbers(item);
                return level;
            }
            else if (element.ValueKind == JsonValueKind.Object)
            {
                var level = 0L;
                foreach (var item in element.EnumerateObject())
                {
                    if (item.Value.ValueKind == JsonValueKind.String && item.Value.GetString()!.Equals("red"))
                        return 0;
                    level += SumChildNumbers(item.Value);
                }

                return level;
            }
            else if (element.ValueKind == JsonValueKind.Number)
            {
                return element.GetInt64();
            }

            return 0;
        }

        private static List<int> GetIntegers(ReadOnlySpan<char> s)
        {
            Span<char> digits = stackalloc char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var result = new List<int>();

            var startIdx = s.IndexOfAny(digits);

            while (startIdx != -1)
            {
                var len = 1;
                while (Char.IsDigit(s[startIdx + len]))
                    len++;

                if (s[startIdx-1] == '-')
                {
                    startIdx--;
                    len++;
                }

                result.Add(int.Parse(s.Slice(startIdx, len)));

                s = s.Slice(startIdx + len);
                startIdx = s.IndexOfAny(digits);
            }

            return result;
        }
    }
}

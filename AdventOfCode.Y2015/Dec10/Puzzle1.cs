namespace AdventOfCode.Y2015.Dec10
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First();

            var result = Process(input, 40);

            return result.Length;
        }

        private static string Process(string input, int cycles)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var current = input.Select(o => o - '0').ToList();

            for (int i = 0; i < cycles; i++)
            {
                var next = new List<int>(current.Count);

                // iterate over, count consecutive items, control break on difference
                var consecutives = 1;
                for (var j = 1; j < current.Count; j++)
                {
                    if (current[j] != current[j - 1])
                    {
                        next.Add(consecutives);
                        next.Add(current[j - 1]);

                        consecutives = 0;
                    }

                    consecutives++;
                }

                next.Add(consecutives);
                next.Add(current.Last());

                current = next;
            }

            return String.Create(current.Count, current, (chars, buffer) =>
            {
                for(var i = 0; i < chars.Length; i++)
                    chars[i] = (char)(buffer[i] + '0');
            });
        }
    }
}

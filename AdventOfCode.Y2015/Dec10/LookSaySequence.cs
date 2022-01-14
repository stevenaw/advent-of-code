namespace AdventOfCode.Y2015.Dec10
{
    internal static class LookSaySequence
    {
        public static string Generate(string input, int cycles)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var current = input.Select(o => (byte)(o - '0')).ToList();

            for (int i = 0; i < cycles; i++)
            {
                // Each sequence will be around 1.31 times longer than previous (Conway's constant)
                var next = new List<byte>((int)Math.Ceiling(current.Count * 1.31));

                byte consecutives = 1;
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
                for (var i = 0; i < chars.Length; i++)
                    chars[i] = (char)(buffer[i] + '0');
            });
        }
    }
}

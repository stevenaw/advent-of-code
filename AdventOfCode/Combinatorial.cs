namespace AdventOfCode
{
    public static class Combinatorial
    {
        public static List<T[]> GetPermutations<T>(T[] seed) where T : class
        {
            var capacity = GetFactorial(seed.Length - 1);
            var tally = new List<T[]>(capacity);
            var rest = new Stack<T>(seed.Reverse());

            // anchor by first item, rest relative to it
            var buffer = new T[seed.Length];
            buffer[0] = rest.Pop();

            BuildIteration(buffer, rest, tally);

            return tally;

            static void BuildIteration(T?[] buffer, Stack<T> rest, List<T[]> tally)
            {
                var c = rest.Count;
                if (c == 0)
                    return;

                var next = rest.Pop();

                for (var i = 1; i < buffer.Length; i++)
                {
                    if (buffer[i] is null)
                    {
                        buffer[i] = next;

                        BuildIteration(buffer, rest, tally);

                        if (!rest.Any())
                            tally.Add((T[])buffer.Clone());

                        buffer[i] = null;
                    }
                }

                rest.Push(next);
            }
        }

        private static int GetFactorial(int n)
        {
            if (n <= 2)
                return n;
            return n * GetFactorial(n - 1);
        }
    }
}

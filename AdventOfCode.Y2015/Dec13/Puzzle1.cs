namespace AdventOfCode.Y2015.Dec13
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var neighbours = Neighbour.ParseMany(lines);
            var distinctNames = neighbours.Select(o => o.PersonA)
                .Union(neighbours.Select(o => o.PersonB))
                .Distinct()
                .ToArray();

            var allCombinations = GetPermutations(distinctNames);
            var optimal = allCombinations.Select(o => CalculateSeatingHappiness(o, neighbours)).Max();

            return optimal;
        }

        private static int CalculateSeatingHappiness(string[] seating, Neighbour[] weights)
        {
            var happiness = 0;
            for (var i = 0; i < seating.Length-1; i++)
                happiness += CalculateHappiness(seating[i], seating[i + 1], weights);

            happiness += CalculateHappiness(seating[seating.Length-1], seating[0], weights);

            return happiness;

            static int CalculateHappiness(string a, string b, Neighbour[] weights)
            {
                var weight = weights.First(o => (o.PersonA == a && o.PersonB == b) || (o.PersonA == b && o.PersonB == a));
                return weight.DeltaHappiness;
            }
        }

        private static List<string[]> GetPermutations(string[] seed)
        {
            var tally = new List<string[]>();
            var rest = new Stack<string>(seed.Reverse());

            // anchor by first item, rest relative to it
            var buffer = new string[seed.Length];
            buffer[0] = rest.Pop();

            BuildIteration(buffer, rest, tally);

            return tally;

            static void BuildIteration(string?[] buffer, Stack<string> rest, List<string[]> tally)
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
                            tally.Add((string[])buffer.Clone());

                        buffer[i] = null;
                    }
                }

                rest.Push(next);
            }
        }
    }
}

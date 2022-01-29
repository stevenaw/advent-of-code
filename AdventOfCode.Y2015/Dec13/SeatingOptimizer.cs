namespace AdventOfCode.Y2015.Dec13
{
    internal static class SeatingOptimizer
    {
        public static int CalculateOptimalHappiness(Neighbour[] weights)
        {
            var distinctNames = weights.Select(o => o.PersonA)
                .Union(weights.Select(o => o.PersonB))
                .Distinct()
                .ToArray();

            var allCombinations = Combinatorial.GetPermutations(distinctNames);
            var optimal = allCombinations.Select(o => CalculateSeatingHappiness(o, weights)).Max();

            return optimal;
        }

        private static int CalculateSeatingHappiness(string[] seating, Neighbour[] weights)
        {
            var happiness = 0;
            for (var i = 0; i < seating.Length - 1; i++)
                happiness += CalculateHappiness(seating[i], seating[i + 1], weights);

            happiness += CalculateHappiness(seating[seating.Length - 1], seating[0], weights);

            return happiness;

            static int CalculateHappiness(string a, string b, Neighbour[] weights)
            {
                // O(n^2), not great
                var weight = weights.First(o => (o.PersonA == a && o.PersonB == b) || (o.PersonA == b && o.PersonB == a));
                return weight.DeltaHappiness;
            }
        }
    }
}

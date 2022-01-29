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

            var weightLookup = weights.ToDictionary(o => GetHashCode(o), o => o.DeltaHappiness);

            var allCombinations = Combinatorial.GetPermutations(distinctNames);
            var optimal = allCombinations.Select(o => CalculateSeatingHappiness(o, weightLookup)).Max();

            return optimal;
        }

        private static int CalculateSeatingHappiness(string[] seating, Dictionary<int,int> weights)
        {
            var happiness = 0;
            for (var i = 0; i < seating.Length - 1; i++)
                happiness += weights[GetHashCode(seating[i], seating[i + 1])];

            happiness += weights[GetHashCode(seating[0], seating[seating.Length - 1])];

            return happiness;
        }

        private static int GetHashCode(Neighbour n) => GetHashCode(n.PersonA, n.PersonB);
        private static int GetHashCode(string a, string b) => a.GetHashCode() ^ b.GetHashCode();
    }
}

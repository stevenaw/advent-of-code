namespace AdventOfCode
{
    public static class FactorizationHelpers
    {
        public static List<int> GetFactors(int num)
        {
            List<int> factors = new List<int>();

            // Iterate up to the square root of the number for efficiency
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    factors.Add(i);
                    // If the factors are not the same (e.g., if num is not a perfect square)
                    // add the pair (num / i) as well
                    if (i != num / i)
                    {
                        factors.Add(num / i);
                    }
                }
            }

            return factors;
        }
    }
}

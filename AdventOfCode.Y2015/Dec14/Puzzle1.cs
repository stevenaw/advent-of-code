namespace AdventOfCode.Y2015.Dec14
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int duration = 2503;
            var furthest = 0;

            foreach (var line in lines)
            {
                var candidate = Reindeer.Parse(line);
                var candidateDistance = CalculateDistance(candidate, duration);

                furthest = Math.Max(candidateDistance, furthest);
            }

            return furthest;
        }

        private static int CalculateDistance(Reindeer reindeer, int duration)
        {
            var distance = 0;
            var timeSpent = 0;

            while (timeSpent < duration)
            {
                var burstTime = Math.Min(reindeer.Stamina, duration - timeSpent);

                distance += (reindeer.Speed * burstTime);
                timeSpent += (burstTime + reindeer.Downtime);
            }

            return distance;
        }
    }
}

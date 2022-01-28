namespace AdventOfCode.Y2015.Dec14
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int duration = 2503;

            var reindeer = lines.Select(l => new ReindeerState(Reindeer.Parse(l))).ToArray();

            for (var sec = 0; sec < duration; sec++)
            {
                for (var i = 0; i < reindeer.Length; i++)
                    reindeer[i].MoveNext();

                reindeer = reindeer.OrderByDescending(o => o.Distance).ToArray();

                for (var i = 0; i < reindeer.Length && reindeer[i].Distance == reindeer[0].Distance; i++)
                    reindeer[i].MarkLeader();
            }

            var winner = reindeer.MaxBy(o => o.Points)!;

            return winner.Points;
        }

        private class ReindeerState
        {
            public ReindeerState(Reindeer reindeer)
            {
                Reindeer = reindeer;
                TimeInState = Reindeer.Stamina;
            }

            public Reindeer Reindeer { get; init; }
            public int Distance { get; private set; } = 0;
            public int Points { get; private set; } = 0;

            private bool IsFlying { get; set; } = true;
            private int TimeInState { get; set; }

            public void MarkLeader()
            {
                Points++;
            }

            public void MoveNext()
            {
                if (IsFlying)
                    Distance += Reindeer.Speed;

                TimeInState--;
                if (TimeInState == 0)
                {
                    IsFlying = !IsFlying;
                    TimeInState = IsFlying ? Reindeer.Stamina : Reindeer.Downtime;
                }
            }
        }
    }
}

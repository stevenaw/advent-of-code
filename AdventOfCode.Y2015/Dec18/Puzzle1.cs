namespace AdventOfCode.Y2015.Dec18
{
    internal class Puzzle1 : AdventPuzzle
    {
        const int StepCount = 100;

        private readonly TimeSpan GenerationLength = TimeSpan.FromMilliseconds(500);
        private readonly bool Interactive = false;

        protected override long Solve(IEnumerable<string> lines)
        {
            bool run = true;

            var life = Life.Parse(lines);


            if (Interactive)
            {
                Console.CancelKeyPress += (sender, e) =>
                {
                    run = false;
                    e.Cancel = true; // Allow us to gracefully end it
                };

                life.Render();
                Thread.Sleep(GenerationLength);
            }


            while (run && life.CurrentGeneration.N < StepCount)
            {
                life.Evolve();

                if (Interactive)
                {
                    life.Render();
                    Thread.Sleep(GenerationLength);
                }
            }

            return life.CountLivingDenizens();
        }
    }
}

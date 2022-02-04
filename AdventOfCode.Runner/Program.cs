namespace AdventOfCode.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var (year, day, puzzleNumber) = ParseArguments(args);
            var result = AdventPuzzle.Solve(year, day, puzzleNumber);

            Console.WriteLine($"Result: {result}");
        }

        private static (int year, int day, int puzzleNumber) ParseArguments(string[] args)
        {
            int year = 0, day = 0, puzzleNumber = 0;

            for (var i = 0; i < args.Length; i += 2)
            {
                switch (args[i])
                {
                    case "--year":
                    case "-y":
                        {
                            year = int.Parse(args[i + 1]);
                            break;
                        }

                    case "--day":
                    case "-d":
                        {
                            day = int.Parse(args[i + 1]);
                            break;
                        }

                    case "--puzzle":
                    case "-p":
                        {
                            puzzleNumber = int.Parse(args[i + 1]);
                            break;
                        }
                }
            }

            return (year, day, puzzleNumber);
        }
    }
}

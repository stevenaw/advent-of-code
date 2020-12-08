using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var (day, puzzleNumber) = ParseArguments(args);

            var puzzle = AdventPuzzleHelper.GetPuzzle(day, puzzleNumber);
            var result = puzzle.Solve();

            Console.WriteLine($"Result: {result.ToString()}");
        }

        private static (int day, int puzzleNumber) ParseArguments(string[] args)
        {
            int day = 0, puzzleNumber = 0;

            for(var i = 0; i < args.Length; i+=2)
            {
                switch (args[i])
                {
                    case "--day":
                    case "-d":
                        {
                            day = Int32.Parse(args[i + 1]);
                            break;
                        }

                    case "--puzzle":
                    case "-p":
                        {
                            puzzleNumber = Int32.Parse(args[i + 1]);
                            break;
                        }
                }
            }

            return (day, puzzleNumber);
        }
    }
}

using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var (year, day, puzzleNumber) = ParseArguments(args);

            var puzzle = AdventPuzzle.GetPuzzle(year, day, puzzleNumber);
            var result = puzzle.Solve();

            Console.WriteLine($"Result: {result.ToString()}");
        }

        private static (int year, int day, int puzzleNumber) ParseArguments(string[] args)
        {
            int year = 0, day = 0, puzzleNumber = 0;

            for(var i = 0; i < args.Length; i+=2)
            {
                switch (args[i])
                {
                    case "--year":
                    case "-y":
                        {
                            year = Int32.Parse(args[i + 1]);
                            break;
                        }

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

            return (year, day, puzzleNumber);
        }
    }
}

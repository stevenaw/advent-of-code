namespace AdventOfCode.Y2020.Dec01
{
    public class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> fileContents)
        {
            var numbers = fileContents.Select(o => int.Parse(o)).ToArray();

            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        return numbers[i] * numbers[j];
                    }
                }
            }

            return 0;
        }
    }
}

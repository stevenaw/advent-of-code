namespace AdventOfCode.Y2016.Dec02
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var result = 0;
            var position = 5;

            foreach (var line in lines)
            {
                foreach (var move in line)
                    position = GetNextPosition(position, move);

                result = result * 10 + position;
            }

            return result;
        }

        private static int GetNextPosition(int current, char move) => move switch
        {
            'U' => current <= 3 ? current : current - 3,
            'L' => (current % 3) == 1 ? current : current - 1,
            'R' => (current % 3) == 0 ? current : current + 1,
            'D' => current >= 7 ? current : current + 3,
            _ => throw new InvalidOperationException("unknown move")
        };
    }
}

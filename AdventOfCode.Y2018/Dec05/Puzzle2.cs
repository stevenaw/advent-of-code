namespace AdventOfCode.Y2018.Dec05
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var data = lines.First().ToArray();
            var min = data.Length;

            for (var i = 0; i < 26; i++)
            {
                var target = (char)('a' + i);
                Span<char> clone = (char[])data.Clone();

                clone.RemoveAll(target);

                min = Math.Min(min, PuzzleHelper.Condense(clone));
            }

            return min;
        }
    }
}

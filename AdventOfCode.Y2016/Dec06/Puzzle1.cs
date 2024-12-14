namespace AdventOfCode.Y2016.Dec06
{
    internal class Puzzle1 : AdventPuzzle<string>
    {
        protected override string Solve(IEnumerable<string> lines)
        {
            const int LettersPerWord = 8;
            const int LettersInAlphabet = 26;

            var letterCounts = new int[LettersPerWord * LettersInAlphabet];

            foreach (var line in lines)
            {
                for(var i = 0; i < LettersPerWord; i++)
                {
                    var letterIdx = line[i] - 'a';
                    letterCounts[i * LettersInAlphabet + letterIdx]++;
                }
            }

            Span<char> answer = stackalloc char[LettersPerWord];
            for (var i = 0; i < LettersPerWord; i++)
            {
                var highestIdx = 0;
                for(var j = 1; j < LettersInAlphabet; j++)
                    if (letterCounts[i * LettersInAlphabet + highestIdx] < letterCounts[i * LettersInAlphabet + j])
                        highestIdx = j;

                var commonestLetter = (char)(highestIdx + 'a');
                answer[i] = commonestLetter;
            }

            return answer.ToString();
        }
    }
}

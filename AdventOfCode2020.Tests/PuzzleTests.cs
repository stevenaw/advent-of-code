using NUnit.Framework;

namespace AdventOfCode2020.Tests
{
    [TestFixture]
    public class PuzzleTests
    {
        [TestCase(1, 1, ExpectedResult = 878724)]
        [TestCase(1, 2, ExpectedResult = 201251610)]
        [TestCase(2, 1, ExpectedResult = 572)]
        [TestCase(2, 2, ExpectedResult = 306)]
        [TestCase(3, 1, ExpectedResult = 244)]
        [TestCase(3, 2, ExpectedResult = 9406609920)]
        [TestCase(4, 1, ExpectedResult = 256)]
        [TestCase(4, 2, ExpectedResult = 198)]
        [TestCase(5, 1, ExpectedResult = 913)]
        [TestCase(5, 2, ExpectedResult = 717)]
        [TestCase(6, 1, ExpectedResult = 6680)]
        [TestCase(6, 2, ExpectedResult = 3117)]
        [TestCase(7, 1, ExpectedResult = 242)]
        [TestCase(7, 2, ExpectedResult = 176035)]
        [TestCase(8, 1, ExpectedResult = 2080)]
        [TestCase(8, 2, ExpectedResult = 2477)]
        [TestCase(9, 1, ExpectedResult = 57195069)]
        [TestCase(9, 1, ExpectedResult = 57195069)]
        [TestCase(9, 2, ExpectedResult = 7409241)]
        [TestCase(10, 1, ExpectedResult = 1998)]
        [TestCase(10, 2, ExpectedResult = 347250213298688)]
        public long VerifyResults(int day, int puzzleNumber)
        {
            var puzzle = AdventPuzzleHelper.GetPuzzle(day, puzzleNumber);
            var result = puzzle.Solve();

            return result;
        }
    }
}
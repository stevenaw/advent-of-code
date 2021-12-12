using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class PuzzleTests
    {
        [TestCase(2015, 1, 1, ExpectedResult = 280)]
        [TestCase(2015, 1, 2, ExpectedResult = 1797)]
        [TestCase(2015, 2, 1, ExpectedResult = 1588178)]
        [TestCase(2015, 2, 2, ExpectedResult = 3783758)]
        [TestCase(2015, 3, 1, ExpectedResult = 2572)]
        [TestCase(2015, 3, 2, ExpectedResult = 2631)]
        [TestCase(2015, 4, 1, ExpectedResult = 346386)]
        [TestCase(2015, 4, 2, ExpectedResult = 9958218)]
        [TestCase(2015, 5, 1, ExpectedResult = 238)]
        [TestCase(2015, 5, 2, ExpectedResult = 69)]
        [TestCase(2015, 6, 1, ExpectedResult = 400410)]

        [TestCase(2020, 1, 1, ExpectedResult = 878724)]
        [TestCase(2020, 1, 2, ExpectedResult = 201251610)]
        [TestCase(2020, 2, 1, ExpectedResult = 572)]
        [TestCase(2020, 2, 2, ExpectedResult = 306)]
        [TestCase(2020, 3, 1, ExpectedResult = 244)]
        [TestCase(2020, 3, 2, ExpectedResult = 9406609920)]
        [TestCase(2020, 4, 1, ExpectedResult = 256)]
        [TestCase(2020, 4, 2, ExpectedResult = 198)]
        [TestCase(2020, 5, 1, ExpectedResult = 913)]
        [TestCase(2020, 5, 2, ExpectedResult = 717)]
        [TestCase(2020, 6, 1, ExpectedResult = 6680)]
        [TestCase(2020, 6, 2, ExpectedResult = 3117)]
        [TestCase(2020, 7, 1, ExpectedResult = 242)]
        [TestCase(2020, 7, 2, ExpectedResult = 176035)]
        [TestCase(2020, 8, 1, ExpectedResult = 2080)]
        [TestCase(2020, 8, 2, ExpectedResult = 2477)]
        [TestCase(2020, 9, 1, ExpectedResult = 57195069)]
        [TestCase(2020, 9, 1, ExpectedResult = 57195069)]
        [TestCase(2020, 9, 2, ExpectedResult = 7409241)]
        [TestCase(2020, 10, 1, ExpectedResult = 1998)]
        [TestCase(2020, 10, 2, ExpectedResult = 347250213298688)]
        [TestCase(2020, 11, 1, ExpectedResult = 2344)]
        [TestCase(2020, 11, 2, ExpectedResult = 2076)]
        [TestCase(2020, 12, 1, ExpectedResult = 1441)]
        [TestCase(2020, 12, 2, ExpectedResult = 61616)]
        [TestCase(2020, 13, 1, ExpectedResult = 3606)]
        [TestCase(2020, 13, 2, ExpectedResult = 379786358533423)]
        [TestCase(2020, 14, 1, ExpectedResult = 5902420735773)]
        [TestCase(2020, 14, 2, ExpectedResult = 3801988250775)]
        [TestCase(2020, 15, 1, ExpectedResult = 1085)]
        [TestCase(2020, 15, 2, ExpectedResult = 10652)]
        [TestCase(2020, 16, 1, ExpectedResult = 20048)]
        [TestCase(2020, 16, 2, ExpectedResult = 4810284647569)]
        [TestCase(2020, 17, 1, ExpectedResult = 242)]
        [TestCase(2020, 17, 2, ExpectedResult = 2292)]
        [TestCase(2020, 18, 1, ExpectedResult = 45283905029161)]
        [TestCase(2020, 18, 2, ExpectedResult = 216975281211165)]
        [TestCase(2020, 19, 1, ExpectedResult = 285)]
        public long VerifyResults(int year, int day, int puzzleNumber)
        {
            var puzzle = AdventPuzzle.GetPuzzle(year, day, puzzleNumber);
            var result = puzzle.Solve();

            return result;
        }
    }
}

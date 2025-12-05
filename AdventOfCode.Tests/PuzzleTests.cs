using NUnit.Framework;
using TestCaseData = AdventOfCode.Tests.AocTestCaseData;

[assembly: Parallelizable(ParallelScope.Children)]

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class PuzzleTests
    {
        [TestCaseSource(nameof(GetTestCases))]
        public TResult VerifyResults<TResult>(int year, int day, int puzzleNumber)
            => AdventPuzzle.Solve<TResult>(year, day, puzzleNumber);

        public static IEnumerable<NUnit.Framework.TestCaseData> GetTestCases()
        {
            yield return new TestCaseData(2015, 1, 1).SetExpectedResult(280);
            yield return new TestCaseData(2015, 1, 2).SetExpectedResult(1797);
            yield return new TestCaseData(2015, 2, 1).SetExpectedResult(1588178);
            yield return new TestCaseData(2015, 2, 2).SetExpectedResult(3783758);
            yield return new TestCaseData(2015, 3, 1).SetExpectedResult(2572);
            yield return new TestCaseData(2015, 3, 2).SetExpectedResult(2631);
            yield return new TestCaseData(2015, 4, 1).SetExpectedResult(346386);
            yield return new TestCaseData(2015, 4, 2).SetExpectedResult(9958218);
            yield return new TestCaseData(2015, 5, 1).SetExpectedResult(238);
            yield return new TestCaseData(2015, 5, 2).SetExpectedResult(69);
            yield return new TestCaseData(2015, 6, 1).SetExpectedResult(400410);
            yield return new TestCaseData(2015, 6, 2).SetExpectedResult(15343601);
            yield return new TestCaseData(2015, 7, 1).SetExpectedResult(46065);
            yield return new TestCaseData(2015, 7, 2).SetExpectedResult(14134);
            yield return new TestCaseData(2015, 8, 1).SetExpectedResult(1333);
            yield return new TestCaseData(2015, 8, 2).SetExpectedResult(2046);
            yield return new TestCaseData(2015, 9, 1).SetExpectedResult(251);
            yield return new TestCaseData(2015, 9, 2).SetExpectedResult(898);
            yield return new TestCaseData(2015, 10, 1).SetExpectedResult(492982);
            yield return new TestCaseData(2015, 10, 2).SetExpectedResult(6989950);
            yield return new TestCaseData(2015, 11, 1).SetExpectedResult("vzbxxyzz");
            yield return new TestCaseData(2015, 11, 2).SetExpectedResult("vzcaabcc");
            yield return new TestCaseData(2015, 12, 1).SetExpectedResult(119433);
            yield return new TestCaseData(2015, 12, 2).SetExpectedResult(68466);
            yield return new TestCaseData(2015, 13, 1).SetExpectedResult(709);
            yield return new TestCaseData(2015, 13, 2).SetExpectedResult(668);
            yield return new TestCaseData(2015, 14, 1).SetExpectedResult(2696);
            yield return new TestCaseData(2015, 14, 2).SetExpectedResult(1084);
            yield return new TestCaseData(2015, 15, 1).SetExpectedResult(21367368);
            yield return new TestCaseData(2015, 15, 2).SetExpectedResult(1766400);
            yield return new TestCaseData(2015, 16, 1).SetExpectedResult(40);
            yield return new TestCaseData(2015, 16, 2).SetExpectedResult(241);
            yield return new TestCaseData(2015, 17, 1).SetExpectedResult(1304);
            yield return new TestCaseData(2015, 17, 2).SetExpectedResult(18);
            yield return new TestCaseData(2015, 18, 1).SetExpectedResult(1061);
            yield return new TestCaseData(2015, 18, 2).SetExpectedResult(1006);
            yield return new TestCaseData(2015, 19, 1).SetExpectedResult(535);

            yield return new TestCaseData(2016, 1, 1).SetExpectedResult(301);
            yield return new TestCaseData(2016, 1, 2).SetExpectedResult(130);
            yield return new TestCaseData(2016, 2, 1).SetExpectedResult(84452);
            yield return new TestCaseData(2016, 2, 2).SetExpectedResult("D65C3");
            yield return new TestCaseData(2016, 3, 1).SetExpectedResult(1032);
            yield return new TestCaseData(2016, 3, 2).SetExpectedResult(1838);
            yield return new TestCaseData(2016, 4, 1).SetExpectedResult(278221);
            yield return new TestCaseData(2016, 4, 2).SetExpectedResult(267);
            yield return new TestCaseData(2016, 5, 1).SetExpectedResult("D4CD2EE1");
            yield return new TestCaseData(2016, 5, 2).SetExpectedResult("F2C730E5");
            yield return new TestCaseData(2016, 6, 1).SetExpectedResult("tsreykjj");
            yield return new TestCaseData(2016, 6, 2).SetExpectedResult("hnfbujie");
            yield return new TestCaseData(2016, 7, 1).SetExpectedResult(105);
            yield return new TestCaseData(2016, 7, 2).SetExpectedResult(258);
            yield return new TestCaseData(2016, 8, 1).SetExpectedResult(123);
            yield return new TestCaseData(2016, 8, 2).SetExpectedResult("AFBUPZBJPS");
            yield return new TestCaseData(2016, 9, 1).SetExpectedResult(70186);
            yield return new TestCaseData(2016, 9, 2).SetExpectedResult(10915059201);
            yield return new TestCaseData(2016, 10, 1).SetExpectedResult(27);
            yield return new TestCaseData(2016, 10, 2).SetExpectedResult(13727);

            yield return new TestCaseData(2017, 1, 1).SetExpectedResult(1343);
            yield return new TestCaseData(2017, 1, 2).SetExpectedResult(1274);
            yield return new TestCaseData(2017, 2, 1).SetExpectedResult(36766);
            yield return new TestCaseData(2017, 2, 2).SetExpectedResult(261);
            yield return new TestCaseData(2017, 3, 1).SetExpectedResult(552);
            yield return new TestCaseData(2017, 4, 1).SetExpectedResult(337);
            yield return new TestCaseData(2017, 4, 2).SetExpectedResult(231);
            yield return new TestCaseData(2017, 5, 1).SetExpectedResult(358131);
            yield return new TestCaseData(2017, 5, 2).SetExpectedResult(25558839);
            yield return new TestCaseData(2017, 6, 1).SetExpectedResult(3156);
            yield return new TestCaseData(2017, 6, 2).SetExpectedResult(1610);
            yield return new TestCaseData(2017, 7, 1).SetExpectedResult("dgoocsw");
            yield return new TestCaseData(2017, 8, 1).SetExpectedResult(4163);
            yield return new TestCaseData(2017, 8, 2).SetExpectedResult(5347);
            yield return new TestCaseData(2017, 9, 1).SetExpectedResult(16869);
            yield return new TestCaseData(2017, 9, 2).SetExpectedResult(7284);
            yield return new TestCaseData(2017, 10, 1).SetExpectedResult(212);
            yield return new TestCaseData(2017, 10, 2).SetExpectedResult("96de9657665675b51cd03f0b3528ba26");

            yield return new TestCaseData(2020, 1, 1).SetExpectedResult(878724);
            yield return new TestCaseData(2020, 1, 2).SetExpectedResult(201251610);
            yield return new TestCaseData(2020, 2, 1).SetExpectedResult(572);
            yield return new TestCaseData(2020, 2, 2).SetExpectedResult(306);
            yield return new TestCaseData(2020, 3, 1).SetExpectedResult(244);
            yield return new TestCaseData(2020, 3, 2).SetExpectedResult(9406609920);
            yield return new TestCaseData(2020, 4, 1).SetExpectedResult(256);
            yield return new TestCaseData(2020, 4, 2).SetExpectedResult(198);
            yield return new TestCaseData(2020, 5, 1).SetExpectedResult(913);
            yield return new TestCaseData(2020, 5, 2).SetExpectedResult(717);
            yield return new TestCaseData(2020, 6, 1).SetExpectedResult(6680);
            yield return new TestCaseData(2020, 6, 2).SetExpectedResult(3117);
            yield return new TestCaseData(2020, 7, 1).SetExpectedResult(242);
            yield return new TestCaseData(2020, 7, 2).SetExpectedResult(176035);
            yield return new TestCaseData(2020, 8, 1).SetExpectedResult(2080);
            yield return new TestCaseData(2020, 8, 2).SetExpectedResult(2477);
            yield return new TestCaseData(2020, 9, 1).SetExpectedResult(57195069);
            yield return new TestCaseData(2020, 9, 1).SetExpectedResult(57195069);
            yield return new TestCaseData(2020, 9, 2).SetExpectedResult(7409241);
            yield return new TestCaseData(2020, 10, 1).SetExpectedResult(1998);
            yield return new TestCaseData(2020, 10, 2).SetExpectedResult(347250213298688);
            yield return new TestCaseData(2020, 11, 1).SetExpectedResult(2344);
            yield return new TestCaseData(2020, 11, 2).SetExpectedResult(2076);
            yield return new TestCaseData(2020, 12, 1).SetExpectedResult(1441);
            yield return new TestCaseData(2020, 12, 2).SetExpectedResult(61616);
            yield return new TestCaseData(2020, 13, 1).SetExpectedResult(3606);
            yield return new TestCaseData(2020, 13, 2).SetExpectedResult(379786358533423);
            yield return new TestCaseData(2020, 14, 1).SetExpectedResult(5902420735773);
            yield return new TestCaseData(2020, 14, 2).SetExpectedResult(3801988250775);
            yield return new TestCaseData(2020, 15, 1).SetExpectedResult(1085);
            yield return new TestCaseData(2020, 15, 2).SetExpectedResult(10652);
            yield return new TestCaseData(2020, 16, 1).SetExpectedResult(20048);
            yield return new TestCaseData(2020, 16, 2).SetExpectedResult(4810284647569);
            yield return new TestCaseData(2020, 17, 1).SetExpectedResult(242);
            yield return new TestCaseData(2020, 17, 2).SetExpectedResult(2292);
            yield return new TestCaseData(2020, 18, 1).SetExpectedResult(45283905029161);
            yield return new TestCaseData(2020, 18, 2).SetExpectedResult(216975281211165);
            yield return new TestCaseData(2020, 19, 1).SetExpectedResult(285);
        }
    }
}

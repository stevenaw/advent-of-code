namespace AdventOfCode.Tests
{
    public class AocTestCaseData : NUnit.Framework.TestCaseData<int, int, int>
    {
        public AocTestCaseData(int year, int day, int puzzleNumber)
            : base(year, day, puzzleNumber)
        {
            // A bit of a hack to remove the generic type from the name
            this.SetName(nameof(PuzzleTests.VerifyResults) + "{a}");
        }

        public NUnit.Framework.TestCaseData SetExpectedResult(string expectedResult)
            => SetExpectedResult<string>(expectedResult);

        public NUnit.Framework.TestCaseData SetExpectedResult(long expectedResult)
            => SetExpectedResult<long>(expectedResult);

        private NUnit.Framework.TestCaseData SetExpectedResult<TResult>(TResult expectedResult)
        {
            this.ExpectedResult = expectedResult;
            TypeArgs = [typeof(TResult)];

            return this;
        }
    }
}

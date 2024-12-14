namespace AdventOfCode.Tests
{
    public class AocTestCaseAttribute : NUnit.Framework.TestCaseAttribute
    {
        public AocTestCaseAttribute(int year, int day, int puzzleNumber)
            : base(year, day, puzzleNumber)
        {
            TypeArgs = [typeof(long)];
        }
    }

    public class AocTestCaseData : NUnit.Framework.TestCaseData
    {
        public AocTestCaseData(int year, int day, int puzzleNumber)
            : base(year, day, puzzleNumber)
        {
            // A bit of a hack
            this.SetName("VerifyResults{a}");
        }

        public NUnit.Framework.TestCaseData SetExpectedResult(string expectedResult)
        {
            this.ExpectedResult = expectedResult;
            TypeArgs = [typeof(string)];

            return this;
        }

        public NUnit.Framework.TestCaseData SetExpectedResult(long expectedResult)
        {
            this.ExpectedResult = expectedResult;
            TypeArgs = [typeof(long)];

            return this;
        }
    }
}

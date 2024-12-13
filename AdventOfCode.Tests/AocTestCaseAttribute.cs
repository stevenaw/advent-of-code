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
}

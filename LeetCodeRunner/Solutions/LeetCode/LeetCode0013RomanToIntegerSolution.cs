using LeetCodeRunner.Infrastructure;

namespace LeetCodeRunner.Solutions.LeetCode
{
    internal class LeetCode0013RomanToIntegerSolution : AbstractSolution<LeetCode0013RomanToIntegerSolution.SolutionInput, int>
    {
        /*
            I - 1
            V - 5
            X - 10
            L - 50
            C - 100
            D - 500
            M - 1000

            I can be placed before V (5) and X (10) to make 4 and 9. 
            X can be placed before L (50) and C (100) to make 40 and 90. 
            C can be placed before D (500) and M (1000) to make 400 and 900.
        */

        public int RomanToInt(string s)
        {
            return -1;
        }

        protected override IEnumerable<SolutionTestCase<SolutionInput, int>> GetTestCases()
        {
            return new SolutionTestCase<SolutionInput, int>[]
            {
                new SolutionTestCase<SolutionInput, int>()
                {
                    Input = new SolutionInput("III"),
                    ExpectedResult = 3
                }
            };
        }

        #region Helpers & Input

        public record SolutionInput(string s);

        protected override bool IsMatch(int v1, int v2) => v1 == v2;
        protected override int RunTestCase(SolutionInput data) => RomanToInt(data.s);

        #endregion
    }
}

using LeetCodeRunner.Infrastructure;

namespace LeetCodeRunner.Solutions.LeetCode
{
    internal class LeetCode0020ValidParenthesesSolution : AbstractSolution<LeetCode0020ValidParenthesesSolution.SolutionInput, bool>
    {
        public bool IsValid(string s)
        {
            if (s.Length % 2 != 0) 
                return false;

            Stack<char> stack = new Stack<char>();
            for (int index = 0; index < s.Length; index++)
            {
                var c = s[index];
                if (c == '{' || c == '(' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    var last = stack.Pop();
                    if (last == '{' && c != '}')
                    {
                        return false;
                    }
                    if (last == '[' && c != ']')
                    {
                        return false;
                    }
                    if (last == '(' && c != ')')
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        protected override IEnumerable<SolutionTestCase<SolutionInput, bool>> GetTestCases()
        {
            return new SolutionTestCase<SolutionInput, bool>[]
            {
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput("()[]{}"),
                    ExpectedResult = true
                },
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput(""),
                    ExpectedResult = true
                },
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput("{}("),
                    ExpectedResult = false
                }
            };
        }

        #region Helpers & Input

        public record SolutionInput(string s);

        protected override bool IsMatch(bool v1, bool v2) => v1 == v2;
        protected override bool RunTestCase(SolutionInput data) => IsValid(data.s);

        #endregion
    }
}

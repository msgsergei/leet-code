using LeetCodeRunner.Infrastructure;

namespace LeetCodeRunner.Solutions.LeetCode
{
    internal class LeetCode0125ValidPalindromeSolution : AbstractSolution<LeetCode0125ValidPalindromeSolution.SolutionInput, bool>
    {
        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char cl = s[left];
                left++;
                if (!Char.IsLetterOrDigit(cl))
                {
                    continue;
                }

                while (left <= right)
                {
                    char cr = s[right];
                    if (!Char.IsLetterOrDigit(cr))
                    {
                        right--;
                        continue;
                    }

                    if (Char.ToLowerInvariant(cr) != Char.ToLowerInvariant(cl))
                    {
                        return false;
                    }

                    right--;
                    break;
                }
            }

            return true;
        }

        protected override IEnumerable<SolutionTestCase<SolutionInput, bool>> GetTestCases()
        {
            return new SolutionTestCase<SolutionInput, bool>[]
            {
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput("ab"),
                    ExpectedResult = false
                },
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput("aa"),
                    ExpectedResult = true
                },
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput("l oo l"),
                    ExpectedResult = true
                },
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput("l o l"),
                    ExpectedResult = true
                },
                new SolutionTestCase<SolutionInput, bool>()
                {
                    Input = new SolutionInput("r a c"),
                    ExpectedResult = false
                },
            };
        }

        #region Helpers & Input

        public record SolutionInput(string s);

        protected override bool IsMatch(bool v1, bool v2) => v1 == v2;
        protected override bool RunTestCase(SolutionInput data) => IsPalindrome(data.s);

        #endregion
    }
}

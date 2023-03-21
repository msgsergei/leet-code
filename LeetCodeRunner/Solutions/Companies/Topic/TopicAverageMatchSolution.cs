using LeetCodeRunner.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRunner.Solutions.Companies.Topic
{
    internal class TopicAverageMatchSolution : AbstractSolution<TopicAverageMatchSolution.INPUT, int>
    {
        int solution(int[] A, int S)
        {
            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                double s = 0;
                for (int j = i; j < A.Length; j++)
                {
                    s += A[j];
                    double avg = s / (j - i + 1);
                    if (avg == S)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        protected override IEnumerable<SolutionTestCase<INPUT, int>> GetTestCases()
        {
            return new SolutionTestCase<INPUT, int>[]
            {
                new SolutionTestCase<INPUT, int>()
                {
                    Input = new INPUT(TestDataGenerator.ArrayInt(666, 100, -100, 100), 10),
                },
                new SolutionTestCase<INPUT, int>()
                {
                    Input = new INPUT(new int[] { 2, 2 }, 2),
                    ExpectedResult = 3
                }
            };
        }

        #region Helpers & Input

        public record INPUT(int[] A, int S)
        {
            protected virtual bool PrintMembers(StringBuilder stringBuilder)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"A = [{string.Join(", ", A)}]");
                stringBuilder.AppendLine($"S = {S}");
                return true;
            }
        }

        protected override bool IsMatch(int v1, int v2) => v1 == v2;
        protected override int RunTestCase(INPUT data) => solution(data.A, data.S);

        #endregion
    }
}

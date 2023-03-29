using LeetCodeRunner.Infrastructure;

namespace LeetCodeRunner.Solutions.Companies.Topic
{
	internal class TopicNumberIncrementSolution : AbstractSolution<TopicNumberIncrementSolution.SolutionInput, int>
	{
		private int solution(int N, int K)
		{
			if (K == 0) return N;

			var numUpdates = K;
			var result = N;

			var f = 100;
			while (f > 0 && numUpdates > 0)
			{
				var d = f * 10;
				var digit = (result % d) / f;
				var adjust = 9 - digit;
				if (adjust > numUpdates)
				{
					adjust = numUpdates;
				}

				result += adjust * f;
				numUpdates -= adjust;
				f /= 10;
			}
			return result;
		}

		protected override IEnumerable<SolutionTestCase<SolutionInput, int>> GetTestCases()
		{
			return new SolutionTestCase<SolutionInput, int>[]
			{
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(920, 7),
					ExpectedResult = 990
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(100, 2),
					ExpectedResult = 300
				}
			};
		}

		#region Helpers & Input

		public record SolutionInput(int N, int K);

		protected override bool IsMatch(int v1, int v2) => v1 == v2;
		protected override int RunTestCase(SolutionInput data) => solution(data.N, data.K);

		#endregion
	}
}

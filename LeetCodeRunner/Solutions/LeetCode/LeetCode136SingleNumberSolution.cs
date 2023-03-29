using LeetCodeRunner.Infrastructure;

namespace LeetCodeRunner.Solutions.LeetCode
{
	internal class LeetCode136SingleNumberSolution : AbstractSolution<LeetCode136SingleNumberSolution.SolutionInput, int>
	{
		public int SingleNumber(int[] nums)
		{
			var res = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				res ^= nums[i];
			}
			return res;
		}

		protected override IEnumerable<SolutionTestCase<SolutionInput, int>> GetTestCases()
		{
			return new SolutionTestCase<SolutionInput, int>[]
			{
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(new int[] { 2, 2, 1 }),
					ExpectedResult = 1
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(new int[] { -100, -100, 6 }),
					ExpectedResult = 6
				},
			};
		}

		#region Helpers & Input

		public record SolutionInput(int[] N);

		protected override bool IsMatch(int v1, int v2) => v1 == v2;
		protected override int RunTestCase(SolutionInput data) => SingleNumber(data.N);

		#endregion
	}
}

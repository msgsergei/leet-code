using LeetCodeRunner.Infrastructure;
using System.Text;

namespace LeetCodeRunner.Solutions.Companies.Topic
{
	internal class TopicAverageMatchSolution : AbstractSolution<TopicAverageMatchSolution.SolutionInput, int>
	{
		int solution_Optimized(int[] A, int S)
		{
			int totalCount = 0;
			int tempSum = 0;

			Dictionary<int, int> sumOccurs = new Dictionary<int, int>();

			for (int i = 0; i < A.Length; i++)
			{
				// Make 'chart' with median around X axis
				tempSum += (A[i] - S);

				// sum[0...i] == 0
				if (tempSum == 0)
				{
					totalCount++;
				}

				if (sumOccurs.ContainsKey(tempSum))
				{
					totalCount += sumOccurs[tempSum];
					sumOccurs[tempSum]++;
				}
				else
				{
					sumOccurs.Add(tempSum, 1);
				}
			}

			return totalCount;
		}

		int solution_Straight(int[] A, int S)
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

		protected override IEnumerable<SolutionTestCase<SolutionInput, int>> GetTestCases()
		{
			var inputCases = new SolutionTestCase<SolutionInput, int>[]
			{
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(TestDataGenerator.ArrayInt(666, 100, -100, 100), 10),
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(TestDataGenerator.ArrayInt(555, 6000, -100000, 100000), 546),
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(new int[] { 2, 2 }, 2),
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(new int[] { -10, 10 }, 0),
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(new int[] { -10, 10 }, 5),
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(new int[] { 1 }, 2),
				},
				new SolutionTestCase<SolutionInput, int>()
				{
					Input = new SolutionInput(new int[] { 1 }, 1),
				}
			};

			foreach (var c in inputCases)
			{
				c.ExpectedResult = solution_Straight(c.Input.A, c.Input.S);
			}

			return inputCases;
		}

		#region Helpers & Input

		public record SolutionInput(int[] A, int S)
		{
			protected virtual bool PrintMembers(StringBuilder stringBuilder)
			{
				stringBuilder.AppendLine();
				const int limit = 30;
				if (A.Length >= limit)
				{
					stringBuilder.AppendLine($"A = [{string.Join(", ", A.Take(limit))}, ... <skipped: {A.Length - limit} items>]");
				}
				else
				{
					stringBuilder.AppendLine($"A = [{string.Join(", ", A)}]");
				}
				stringBuilder.AppendLine($"S = {S}");
				return true;
			}
		}

		protected override bool IsMatch(int v1, int v2) => v1 == v2;
		protected override int RunTestCase(SolutionInput data) => solution_Optimized(data.A, data.S);

		#endregion
	}
}

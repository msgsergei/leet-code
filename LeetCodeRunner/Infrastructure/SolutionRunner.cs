namespace LeetCodeRunner.Infrastructure
{
	internal static class SolutionRunner
	{
		public static void Run<T>()
			where T : ISolution, new()
		{
			var solution = new T();
			solution.Run();
		}
	}
}

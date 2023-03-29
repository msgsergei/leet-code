using System.Diagnostics;

namespace LeetCodeRunner.Infrastructure
{
	internal abstract class AbstractSolution<TInput, TOutput> : ISolution
	{
		public void Run()
		{
			WriteBeginStatement();

			var testCases = GetTestCases();
			foreach (var test in testCases)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				Exception? runtimeError = default;
				TOutput result = default;
				try
				{
					result = RunTestCase(test.Input);
				}
				catch (Exception exc)
				{
					runtimeError = exc;
				}
				finally
				{
					stopwatch.Stop();
				}
				DumpResult(test, result!, runtimeError, stopwatch.Elapsed);
			}

			WriteEndStatement();
		}

		private void DumpResult(SolutionTestCase<TInput, TOutput> testCase, TOutput result, Exception? runtimeError, TimeSpan elapsed)
		{
			Console.WriteLine($"-> {testCase.Input}");

			if (runtimeError != null)
			{
				Console.WriteLine($"ERROR: {runtimeError.Message}");
			}
			else
			{
				Console.WriteLine($"-> ACTUAL: {result}");
				if (testCase.ExpectedResult != null && !testCase.IsNoExpectedResult)
				{
					bool isMatch = IsMatch(testCase.ExpectedResult, result);
					Console.WriteLine($"-> EXPECTED: {testCase.ExpectedResult} | {(isMatch ? "Match" : "ERROR !!!")}");
				}
			}
			Console.WriteLine($"-> DURATION (ms): {elapsed.TotalMilliseconds}");
			Console.WriteLine();
		}

		private void WriteBeginStatement()
		{
			Console.WriteLine(Delimiter);
			Console.WriteLine(Title);
			Console.WriteLine(Delimiter);
		}

		private void WriteEndStatement()
		{
			Console.WriteLine(Delimiter);
			Console.WriteLine("SOLUTION END");
			Console.WriteLine(Delimiter);
		}

		private string Delimiter => new string('-', Title.Length);
		private string Title => $"{GetType().Name} [ {GetType().FullName} ]";

		protected abstract IEnumerable<SolutionTestCase<TInput, TOutput>> GetTestCases();
		protected abstract TOutput RunTestCase(TInput data);
		protected abstract bool IsMatch(TOutput v1, TOutput v2);
	}
}

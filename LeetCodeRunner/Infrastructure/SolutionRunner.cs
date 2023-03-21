using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

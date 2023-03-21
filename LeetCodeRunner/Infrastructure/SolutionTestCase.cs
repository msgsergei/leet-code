using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRunner.Infrastructure
{
    internal class SolutionTestCase<TInput, TOutput>
    {
        private bool _noExpectedResult = true;
        private TOutput _expectedResult;

        public TInput Input { get; set; } = default!;

        public TOutput ExpectedResult
        {
            get => _expectedResult;
            set
            {
                _noExpectedResult = false;
                _expectedResult = value;
            }
        }

        public bool IsNoExpectedResult => _noExpectedResult;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRunner.Infrastructure
{
    internal static class TestDataGenerator
    {    
        public static int[] ArrayInt(int seed, int length, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            Random rnd = new Random(seed);
            var array = Enumerable.Range(0, length).ToArray();
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = rnd.Next(minValue, maxValue);
            }
            return array;
        }
    }
}

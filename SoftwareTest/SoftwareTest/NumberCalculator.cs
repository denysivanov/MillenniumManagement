using System.Collections.Generic;
using System.Linq;

namespace SoftwareTest
{
    public class NumberCalculator : IChallenge
    {
        public int FindMax(int[] numbers)
        {
            return numbers.Max();
        }

        public int[] FindMax(int[] numbers, int n)
        {
            var sortedNumbers = Sort(numbers);

            if (sortedNumbers.Length <= n)
                return sortedNumbers;

            var startOfMaxSequence = sortedNumbers.Length - n;

            return GetPartOfArray(sortedNumbers, startOfMaxSequence);
        }

        public int[] GetPartOfArray(int[] numbers, int startingSequence)
        {
            var returnValue = new List<int>();

            for (var i = startingSequence; i < numbers.Length - 1; i++)
            {
                returnValue.Add(numbers[i]);
            }

            return returnValue.ToArray();
        }

        public int[] Sort(int[] numbers)
        {
            return numbers.OrderBy(x => x).ToArray(); 
        }

        public bool Winner()
        {
            var numbers = new[] { 5, 7, 5, 3, 6, 7, 9 };
            var sorted = Sort(numbers);
            var maxes = FindMax(numbers, 2);

            // TODO: Are the following test cases sufficient, to prove your code works
            // as expected? If not either write more test cases and/or describe what
            // other tests cases would be needed.

            return sorted.First() == 3
                   && sorted.Last() == 9
                   && FindMax(numbers) == 9
                   && maxes[0] == 9
                   && maxes[1] == 7;
        }
    }
}
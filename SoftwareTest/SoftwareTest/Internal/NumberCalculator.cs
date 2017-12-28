using System.Linq;

namespace SoftwareTest.Internal
{
    public class NumberCalculator : IChallenge
    {
        public int FindMax(int[] numbers) => numbers.Max();
        

        public int[] FindMax(int[] numbers, int n)
        {
            if (numbers.Length <= n)
                return numbers;

            return numbers.OrderByDescending(x => x).Take(n).ToArray();
        }

        public int[] Sort(int[] numbers) => numbers.OrderBy(x => x).ToArray(); 


        //test are done in SoftwareTest.Test project
        public bool Winner()
        {
            var numbers = new[] { 5, 7, 5, 3, 6, 7, 9 };
            var sorted = Sort(numbers);
            var maxes = FindMax(numbers, 2);

            return sorted.First() == 3
                   && sorted.Last() == 9
                   && FindMax(numbers) == 9
                   && maxes[0] == 9
                   && maxes[1] == 7;
        }
    }
}
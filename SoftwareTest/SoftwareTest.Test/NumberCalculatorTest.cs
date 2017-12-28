using NUnit.Framework;

namespace SoftwareTest.Test
{
    [TestFixture]
    public class NumberCalculatorTest
    {
        private readonly int[] _numbers = new[] { 5, 7, 5, 3, 6, 7, 9 };
        private readonly NumberCalculator _numberCalculator = new NumberCalculator();

        [Test]
        public void FindMaxNumberTest()
        {
            var max = _numberCalculator.FindMax(_numbers);

            foreach (var number in _numbers)
            {
                Assert.GreaterOrEqual(max, number);
            }
        }

        [Test]
        public void SortTest()
        {
            var minNumber = int.MinValue;
            var sorted = _numberCalculator.Sort(_numbers);

            for (int i = 0; i < sorted.Length; i++)
            {
                Assert.LessOrEqual(minNumber, sorted[i]);
                minNumber = sorted[i];
            }
        }
    }
}
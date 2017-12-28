using System.Linq;
using NUnit.Framework;

namespace SoftwareTest.Test
{
    [TestFixture]
    public class NumberCalculatorTest
    {
        private readonly int[] _numbers = {5, 7, 5, 3, 6, 7, 9};
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
        public void FindMaxNumberCheckByNumberTest()
        {
            var max = _numberCalculator.FindMax(_numbers);

            Assert.GreaterOrEqual(9, max);
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

        [Test]
        public void SortNumberFirstTest()
        {
            var sorted = _numberCalculator.Sort(_numbers);

            Assert.AreEqual(3, sorted.First());
        }

        [Test]
        public void SortNumberLastTest()
        {
            var sorted = _numberCalculator.Sort(_numbers);

            Assert.AreEqual(9, sorted.Last());
        }

        [Test]
        public void SortNumberByHighestNumber_firstElement_Test()
        {
            var maxes = _numberCalculator.FindMax(_numbers, 2);
            Assert.AreEqual(9, maxes[0]);
        }

        [Test]
        public void SortNumberByHighestNumber_lastElement_Test()
        {
            var maxes = _numberCalculator.FindMax(_numbers, 2);
            Assert.AreEqual(7, maxes[1]);
        }

        [Test]
        public void SortNumberByHighestNumber_numberOfElements_Test()
        {
            for (int i = 0; i < _numbers.Length; i++)
            {
                var maxes = _numberCalculator.FindMax(_numbers, i);
                Assert.AreEqual(i, maxes.Length);
            }
        }

        [Test]
        public void SortNumberByHighestNumber_sortingOrder_Test()
        {
            for (int i = 1; i < _numbers.Length; i++)
            {
                var maxNumber = int.MaxValue;
                var maxes = _numberCalculator.FindMax(_numbers, i);

                for (int j = 0; j < maxes.Length - 1; j++)
                {
                    Assert.GreaterOrEqual(maxNumber, maxes[j]);
                }
            }
        }
    }
}
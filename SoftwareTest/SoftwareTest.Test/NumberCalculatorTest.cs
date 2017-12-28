using System;
using System.Linq;
using NUnit.Framework;
using SoftwareTest.Internal;

namespace SoftwareTest.Test
{
    [TestFixture]
    public class NumberCalculatorTest
    {
        //{5, 7, 5, 3, 6, 7, 9};
        private readonly int[] _numbers = RandomNumber();
        private readonly NumberCalculator _numberCalculator = new NumberCalculator();

        private static int[] RandomNumber()
        {
            var randNum = new Random();

            var arraySize = randNum.Next(0, 100);

            var maxValueOfElement = randNum.Next(0, 1000);

            return Enumerable
                .Repeat(0, arraySize)
                .Select(i => randNum.Next(0, maxValueOfElement))
                .ToArray();
        }

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

        [Test]
        public void SortNumberFirstTest()
        {
            var sorted = _numberCalculator.Sort(_numbers);

            Assert.AreEqual(_numbers.Min(), sorted.First());
        }

        [Test]
        public void SortNumberLastTest()
        {
            var sorted = _numberCalculator.Sort(_numbers);

            Assert.AreEqual(_numbers.Max(), sorted.Last());
        }

        [Test]
        public void SortNumberByHighestNumber_firstElement_Test()
        {
            
            for (var i = 1; i < _numbers.Length; i++)
            {
                var maxes = _numberCalculator.FindMax(_numbers, i);
                Assert.AreEqual(_numbers.Max(), maxes[0]);
            }
        }

        [Test]
        public void SortNumberByHighestNumber_lastElement_Test()
        {

            for (var i = 1; i < _numbers.Length; i++)
            {
                var maxes = _numberCalculator.FindMax(_numbers, i);
                Assert.LessOrEqual(maxes[maxes.Length - 1], maxes[0]);
            }
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
        public void SortNumberByHighestNumber_allValuesInSourceLessThenMax_Test()
        {
            for (int i = 1; i < _numbers.Length; i++)
            {
                var maxes = _numberCalculator.FindMax(_numbers, i);
                var maxNumber = maxes.Max();
                Assert.IsFalse(_numbers.Any(x => x > maxNumber));
            }
        }

        [Test]
        public void SortNumberByHighestNumber_minValuesInSourceEqualOrLessThenMin_Test()
        {
            for (int i = 1; i < _numbers.Length; i++)
            {
                var maxes = _numberCalculator.FindMax(_numbers, i);
                Assert.LessOrEqual(_numbers.Min(), maxes.Min());
            }
        }

        [Test]
        public void SortNumberByHighestNumber_MinResultHaveSomeValuesInSourceBefore_Test()
        {
            if (_numbers.Length < 2)
                return;

            for (int i = 1; i < _numbers.Length - 2; i++)
            {
                var maxes = _numberCalculator.FindMax(_numbers, i);
                var min = maxes.Min();
                var count = _numbers.Count(x => x <= min);
                Assert.Greater(count, 1);
            }
        }
    }
}
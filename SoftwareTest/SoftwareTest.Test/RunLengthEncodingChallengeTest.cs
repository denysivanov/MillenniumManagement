using System;
using System.Linq;
using NUnit.Framework;
using SoftwareTest.Internal;

namespace SoftwareTest.Test
{
    [TestFixture]
    public class RunLengthEncodingChallengeTest
    {
        private byte[] Encode(byte[] original)
        {
            var runLengthEncodingChallenge = new RunLengthEncodingChallenge();
            return runLengthEncodingChallenge.Encode(original);

        }

        [Test]
        public void PresetDataTest()
        {
            var testCases = new[]
            {
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x02, 0x03, 0x04}, new byte[]{0x01, 0x01, 0x01, 0x02, 0x01, 0x03, 0x01, 0x04}),
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x01, 0x01}, new byte[]{0x04, 0x01}),
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x02, 0x02}, new byte[]{0x02, 0x01, 0x02, 0x02})
            };

            foreach (var testCase in testCases)
            {
                var encoded = Encode(testCase.Item1);
                Assert.IsTrue(encoded.SequenceEqual(testCase.Item2));
            }
        }

        private static byte[] ByteArray(int arraySize, byte elementValue)
        {
            return Enumerable.Repeat(0, arraySize).Select(i => elementValue).ToArray();
        }


        [Test]
        public void Check256Behaviour()
        {
            var encoded = Encode(ByteArray(256, 1));
            Assert.AreEqual(4, encoded.Length);
        }

        [Test]
        public void OneUniqueElemet_when_less_256_produce_two_elements([Range(1, 255)] byte i)
        {
            var encoded = Encode(ByteArray(i, i));
            Assert.AreEqual(2, encoded.Length);
        }

        [Test]
        public void EmptyArray_Return_Empty_Array ()
        {
            var encoded = Encode(new byte[0]);
            Assert.AreEqual(0, encoded.Length);
        }

        [Test]
        public void NullArray_Return_Empty_Array()
        {
            var encoded = Encode(null);
            Assert.AreEqual(0, encoded.Length);
        }

        private static byte[] RandomArray()
        {
            var randNum = new Random();

            var arraySize = randNum.Next(1, 1000);

            byte[] returnValue = new byte[arraySize];

            randNum.NextBytes(returnValue);

            return returnValue;
        }

        [Test]
        public void CheckPopulationAllValues()
        {
            var randomArray = RandomArray();
            var encoded = Encode(randomArray);

            var oddCategories = encoded.Where((cat, index) => index % 2 != 0);

            foreach (var element in randomArray)
            {
                Assert.True(oddCategories.Any( x => x == element));
            }
        }

        [Test]
        public void CheckTotalNumberOfElements()
        {
            var randomArray = RandomArray();
            var encoded = Encode(randomArray);

            var numberOfElements = encoded.Where((cat, index) => index % 2 == 0).Sum(x => x);

            Assert.AreEqual(randomArray.Length, numberOfElements);
        }
    }
}
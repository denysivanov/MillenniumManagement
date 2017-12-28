using NUnit.Framework;
using SoftwareTest.Internal;

namespace SoftwareTest.Test
{
    [TestFixture]
    public class RunLengthEncodingChallengeTest
    {
        private byte[] testData = new byte[] {0x01, 0x01, 0x01, 0x02, 0x01, 0x03, 0x01, 0x04};


        private byte[] Encode(byte[] original)
        {
            var runLengthEncodingChallenge = new RunLengthEncodingChallenge();
            return runLengthEncodingChallenge.Encode(original);

        }

        [Test]
        public void BasicTest()
        {
            var results = Encode(testData);
        }

    }
}
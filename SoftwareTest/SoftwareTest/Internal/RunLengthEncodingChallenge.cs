using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareTest.Internal
{
    public class RunLengthEncodingChallenge : IChallenge
    {
        public byte[] Encode(byte[] original)
        {
            if (original.Length == 0)
                return new byte[0];
            
            var outPut = new List<byte>{ 0, original[0] };
            
            foreach (var b in original)
            {
                if (IsUpdateCount(b, outPut))
                {
                    outPut[outPut.Count - 2]++;
                    continue;
                }

                outPut.AddRange(new byte [] { 1, b });
            }

            return outPut.ToArray();
        }

        private static bool IsUpdateCount(byte b, List<byte> outPut)
        {
            if (b != outPut[outPut.Count - 1])
                return false;

            if (outPut[outPut.Count - 2] == 255)
                return false;

            return true;
        }

        public bool Winner()
        {
            //See test project

            var testCases = new[]
            {
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x02, 0x03, 0x04}, new byte[]{0x01, 0x01, 0x01, 0x02, 0x01, 0x03, 0x01, 0x04}),
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x01, 0x01}, new byte[]{0x04, 0x01}),
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x02, 0x02}, new byte[]{0x02, 0x01, 0x02, 0x02})
            };

            // TODO: What limitations does your algorithm have (if any)?
            // Denys Ivanov:  When I am getting count > byte size (> 255) I have to start new sequence
            
            // TODO: What do you think about the efficiency of this algorithm for encoding data?
            // Denys Ivanov: When we are getting unique numbers or small array produced array have bigger size

            foreach (var testCase in testCases)
            {
                var encoded = Encode(testCase.Item1);
                var isCorrect = encoded.SequenceEqual(testCase.Item2);

                if (!isCorrect)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
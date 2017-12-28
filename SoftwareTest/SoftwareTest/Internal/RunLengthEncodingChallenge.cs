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

            byte byteCount = 0;
            
            var outPut = new List<byte>{ byteCount, original[0] };
            
            foreach (var b in original)
            {
                var currentByte = outPut[outPut.Count - 1];

                if (currentByte == b)
                {
                    byteCount++;
                    outPut[outPut.Count - 2] = byteCount;
                    continue;
                }

                byteCount = 1;
                outPut.AddRange(new byte [] { byteCount, b });
            }
           

            return outPut.ToArray();
        }

        public bool Winner()
        {
            // TODO: Are the following test cases sufficient, to prove your code works
            // as expected? If not either write more test cases and/or describe what
            // other tests cases would be needed.

            var testCases = new[]
            {
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x02, 0x03, 0x04}, new byte[]{0x01, 0x01, 0x01, 0x02, 0x01, 0x03, 0x01, 0x04}),
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x01, 0x01}, new byte[]{0x04, 0x01}),
                new Tuple<byte[], byte[]>(new byte[]{0x01, 0x01, 0x02, 0x02}, new byte[]{0x02, 0x01, 0x02, 0x02})
            };

            // TODO: What limitations does your algorithm have (if any)?
            // TODO: What do you think about the efficiency of this algorithm for encoding data?

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
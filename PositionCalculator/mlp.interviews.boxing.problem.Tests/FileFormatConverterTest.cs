using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Implementation.Utility;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;
using NUnit.Framework;

namespace mlp.interviews.boxing.problem.Tests
{
    [TestFixture]
    public class FileFormatConverterTest
    {
        private readonly List<OutputRecord> _outPutRecords = new List<OutputRecord>
        {
            new OutputRecord{Trader = "T1",Symbol = "S1", Quantity = 1},
            new OutputRecord{Trader = "T2",Symbol = "S2", Quantity = 2},
            new OutputRecord{Trader = "T3",Symbol = "S3", Quantity = 3}
        };

        private readonly IFileFormatConverter _fileFormatConverter = new FileFormatConverter();

        [Test]
        public void HeaderShouldExists()
        {
            var result = _fileFormatConverter.Convert(_outPutRecords);
            var expectedNumberOfRecords = _outPutRecords.Count + 1;
            Assert.AreEqual(expectedNumberOfRecords, result.Length);
        }

        [Test]
        public void HeaderValuesAreHardcoded()
        {
            var result = _fileFormatConverter.Convert(_outPutRecords);
            var header = result[0];
            Assert.AreEqual("TRADER,SYMBOL,QUANTITY", header);
        }

        [Test]
        public void RecordValueCheck()
        {
            var result = _fileFormatConverter.Convert(_outPutRecords);
            foreach (var netPosition in _outPutRecords)
            {
                Assert.IsTrue(result.Any(x => x.Equals($"{netPosition.Trader},{netPosition.Symbol},{netPosition.Quantity}")));
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Implementation.Utility;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace mlp.interviews.boxing.problem.Tests
{
    [TestFixture]
    public class NetPositionFileFormatConverterTest
    {
        private readonly List<OutputRecord> _netPositions = new List<OutputRecord>
        {
            new OutputRecord{Trader = "T1",Symbol = "S1", Quantity = 1},
            new OutputRecord{Trader = "T2",Symbol = "S2", Quantity = 2},
            new OutputRecord{Trader = "T3",Symbol = "S3", Quantity = 3}
        };

        private IFileFormatConverter _fileFormatConverter;

        [SetUp]
        public void Setup()
        {
            var netPositionCalculatorMock = new Mock<INetPositionCalculator>();
            netPositionCalculatorMock.Setup(x => x.Calculate(It.IsAny<List<TestRecord>>())).Returns(_netPositions);
            _fileFormatConverter = new FileFormatConverter(netPositionCalculatorMock.Object);
        }

        private string[] TestConverter()
        {
            //it doens't matter what we pass in here, results from calculator are mocked 
            return _fileFormatConverter.Converter(null); 
        }

        [Test]
        public void HeaderShouldExists()
        {
            var result = TestConverter();
            var expectedNumberOfRecords = _netPositions.Count + 1;
            Assert.AreEqual(expectedNumberOfRecords, result.Length);
        }

        [Test]
        public void HeaderValuesAreHardcoded()
        {
            var result = TestConverter();
            var header = result[0];
            Assert.AreEqual("TRADER,SYMBOL,QUANTITY", header);
        }

        [Test]
        public void RecordValueCheck()
        {
            var result = TestConverter();
            foreach (var netPosition in _netPositions)
            {
               Assert.IsTrue(result.Any(x => x.Equals($"{netPosition.Trader},{netPosition.Symbol},{netPosition.Quantity}")));
            }
        }
    }
}
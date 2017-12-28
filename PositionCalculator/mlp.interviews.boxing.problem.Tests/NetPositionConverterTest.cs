using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Implementation.NetPosition;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace mlp.interviews.boxing.problem.Tests
{
    [TestFixture]
    public class NetPositionConverterTest
    {
        private readonly List<NetPosition> _netPositions = new List<NetPosition>
        {
            new NetPosition{Trader = "T1",Symbol = "S1", Quantity = 1},
            new NetPosition{Trader = "T2",Symbol = "S2", Quantity = 2},
            new NetPosition{Trader = "T3",Symbol = "S3", Quantity = 3}
        };

        private INetPositionConverter _netPositionConverter;

        [SetUp]
        public void Setup()
        {
            var netPositionCalculatorMock = new Mock<INetPositionCalculator>();
            netPositionCalculatorMock.Setup(x => x.Calculate(It.IsAny<List<TestRecord>>())).Returns(_netPositions);
            _netPositionConverter = new NetPositionConverter(netPositionCalculatorMock.Object);
        }

        private string[] TestConverter()
        {
            //it doens't matter what we pass in here, results from calculator are mocked 
            return _netPositionConverter.Converter(null); 
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
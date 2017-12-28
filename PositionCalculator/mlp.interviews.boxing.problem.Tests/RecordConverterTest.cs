using mlp.interviews.boxing.problem.Implementation.Utility;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace mlp.interviews.boxing.problem.Tests
{
    [TestFixture]
    public class RecordConverterTest
    {
        private readonly string[] _records = new string[ ]
        {
            "trader,broker,symbol,quantity,price",
            "Anna,DB,IBM.N,100,12",
            "Julie,MS,IBM.N,600,12",
            "Tom,ML,PEP.N,400,10"
        };
        private IRecordConverter _recordConverter;

        [SetUp]
        public void Setup()
        {
            var fileOperationsMock = new Mock<IFileOperations>();
            fileOperationsMock.Setup(x => x.GetData(It.IsAny<string>())).Returns(_records);
            _recordConverter = new RecordConverter(fileOperationsMock.Object);
        }

        public TestRecord[] Results()
        {
            return _recordConverter.GetRecords("someFile").ToArray();
        }

        [Test]
        public void NumberOfRecordCheck()
        {
            var lenght = Results().Length;

            Assert.AreEqual(3, lenght);
        }

        [Test]
        public void TraderConversion()
        {
            var trader = Results()[0].Trader;

            Assert.AreEqual("Anna", trader);
        }

        [Test]
        public void BrokerConversion()
        {
            var broker = Results()[1].Broker;

            Assert.AreEqual("MS", broker);
        }

        [Test]
        public void SymbolConversion()
        {
            var symbol = Results()[2].Symbol;

            Assert.AreEqual("PEP.N", symbol);
        }

        [Test]
        public void QuantityConversion()
        {
            var quantity = Results()[0].Quantity;

            Assert.AreEqual(100, quantity);
        }

        [Test]
        public void PriceConversion()
        {
            var price = Results()[2].Price;

            Assert.AreEqual(10d, price);
        }
    }
}
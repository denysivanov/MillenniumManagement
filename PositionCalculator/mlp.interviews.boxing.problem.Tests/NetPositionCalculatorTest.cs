using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Implementation.NetPosition;
using mlp.interviews.boxing.problem.Interface.Entity;
using NUnit.Framework;

namespace mlp.interviews.boxing.problem.Tests
{
    [TestFixture]
    public class NetPositionCalculatorTest
    {
        private readonly List<TestRecord> _testRecords = new List<TestRecord>
        {
            new TestRecord{Trader = "Joe", Broker = "ML", Symbol = "IBM.N", Quantity = 100, Price = 50},
            new TestRecord{Trader = "Joe", Broker = "DB", Symbol = "IBM.N", Quantity = -50, Price = 50},
            new TestRecord{Trader = "Joe", Broker = "CS", Symbol = "IBM.N", Quantity = 30, Price = 30},
            new TestRecord{Trader = "Mike", Broker = "CS", Symbol = "AAPL.N", Quantity = 100, Price = 20},
            new TestRecord{Trader = "Mike", Broker = "BC", Symbol = "AAPL.N", Quantity = 200, Price = 20},
            new TestRecord{Trader = "Debby", Broker = "BC", Symbol = "NVDA.N", Quantity = 500, Price = 20}
        };

        private List<NetPosition> GetResults()
        {
            var calculator = new NetPositionCalculator();
            return calculator.Calculate(_testRecords);
        }

        [Test]
        public void NumberOfRecords()
        {
            var result = GetResults();
            var resultCount = result.Count;
            Assert.AreEqual(3, resultCount);
        }

        private int GetQuantity(string trader, string symbol)
        {
            return GetResults().First(x => x.Trader == trader && x.Symbol == symbol).Quantity;
        }


        private readonly List<NetPosition> _resultRecords = new List<NetPosition>
        {
            new NetPosition{Trader = "Joe",Symbol = "IBM.N", Quantity = 80},
            new NetPosition{Trader = "Mike",Symbol = "AAPL.N", Quantity = 300},
            new NetPosition{Trader = "Debby",Symbol = "NVDA.N", Quantity = 500},
        };
       

        [Test]
        public void CheckValues()
        {
            foreach (var resultRecord in _resultRecords)
            {
                var quantity = GetQuantity(resultRecord.Trader, resultRecord.Symbol);
                Assert.AreEqual(resultRecord.Quantity, quantity);
            }
        }
    }
}
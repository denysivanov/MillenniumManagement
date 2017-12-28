using System.Collections.Generic;
using mlp.interviews.boxing.problem.Implementation.BoxedPosition;
using mlp.interviews.boxing.problem.Interface.Entity;
using NUnit.Framework;

namespace mlp.interviews.boxing.problem.Tests
{
    [TestFixture]
    public class BoxedPositionDetectorTest
    {
        private bool IsBoxedPosionExists(List<TestRecord> testRecords)
        {
            var detector = new BoxedPositionDetector();
            foreach (var testRecord in testRecords)
            {
                var isBoxedPosition = detector.IsBoxedPosition(testRecords, testRecord);
                if (isBoxedPosition)
                    return true;
            }
            return false;
        }

        /*
         * This is an example of a boxed position:
         * TRADER   BROKER  SYMBOL  QUANTITY    PRICE
         * Joe      ML      IBM.N     100         50      <------Has at least one positive quantity for Trader = Joe and Symbol = IBM
         * Joe      DB      IBM.N    -50          50      <------Has at least one negative quantity for Trader = Joe and Symbol = IBM
         * Joe      CS      IBM.N     30          30
         */

        private readonly List<TestRecord> _differentBrokerTheSameTraderRecords = new List<TestRecord>
        {
            new TestRecord{Trader = "Joe", Broker = "ML", Symbol = "IBM.N", Quantity = 100, Price = 50},
            new TestRecord{Trader = "Joe", Broker = "DB", Symbol = "IBM.N", Quantity = -50, Price = 50},
            new TestRecord{Trader = "Joe", Broker = "CS", Symbol = "IBM.N", Quantity = 100, Price = 50},
        };


        [Test]
        public void DifferentBrokerTheSameTrader()
        {
            var isBoxedPosionExists = IsBoxedPosionExists(_differentBrokerTheSameTraderRecords);
            Assert.IsTrue(isBoxedPosionExists);
        }

        /*
         * This is NOT a boxed position. Since no trader has both long and short positions at different brokers.
         * TRADER   BROKER  SYMBOL  QUANTITY    PRICE
         * Joe      ML      IBM.N     100         50
         * Joe      DB      IBM.N     50          50
         * Joe      CS      IBM.N     30          30
         * Mike     DB      IBM.N    -50          50
        */

        private readonly List<TestRecord> _differentBrokerDifferentTraderRecords = new List<TestRecord>
        {
            new TestRecord{Trader = "Joe", Broker = "ML", Symbol = "IBM.N", Quantity = 100, Price = 50},
            new TestRecord{Trader = "Joe", Broker = "DB", Symbol = "IBM.N", Quantity = 50, Price = 50},
            new TestRecord{Trader = "Joe", Broker = "CS", Symbol = "IBM.N", Quantity = 30, Price = 50},
            new TestRecord{Trader = "Mike", Broker = "DB", Symbol = "IBM.N", Quantity = -50, Price = 50},
        };

        [Test]
        public void DifferentBrokerDifferentTraderRecords()
        {
            var isBoxedPosionExists = IsBoxedPosionExists(_differentBrokerDifferentTraderRecords);
            Assert.IsFalse(isBoxedPosionExists);
        }
    }
}
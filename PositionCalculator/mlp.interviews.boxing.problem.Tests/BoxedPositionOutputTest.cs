using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Implementation.BoxedPosition;
using mlp.interviews.boxing.problem.Interface.Entity;
using NUnit.Framework;

namespace mlp.interviews.boxing.problem.Tests
{
    [TestFixture]
    public class BoxedPositionOutputTest
    {
        private List<OutputRecord> Getter(List<OutputRecord> convertedRecords)
        {
            var boxedPositionOutput = new BoxedPositionOutput();
            return boxedPositionOutput.Get(convertedRecords);
        }

        /*
         * This is an example of a boxed position:
         * TRADER   BROKER  SYMBOL  QUANTITY    PRICE
         * Joe      ML      IBM.N     100         50      <------Has at least one positive quantity for Trader = Joe and Symbol = IBM
         * Joe      DB      IBM.N    -50          50      <------Has at least one negative quantity for Trader = Joe and Symbol = IBM
         * Joe      CS      IBM.N     30          30
        */

        private List<Interface.Entity.OutputRecord> testData = new List<Interface.Entity.OutputRecord>
        {
            new OutputRecord{Trader = "Joe",Symbol = "IBM.M", Quantity = 100},
            new OutputRecord{Trader = "Joe",Symbol = "IBM.M", Quantity = -50},
            new OutputRecord{Trader = "Joe",Symbol = "IBM.M", Quantity = 30},
        };

        /*
         * * Expected Output:
         * TRADER   SYMBOL  QUANTITY
         * Joe      IBM.N     50        <------Show the minimum quantity of all long positions or the absolute sum of all short positions. ie. minimum of (100 + 30) and abs(-50) is 50
         */

        [Test]
        public void QuantityCheck()
        {
            var result = Getter(testData);
            var quantity = testData.First().Quantity;
            Assert.AreEqual(50, quantity);
        }

        [Test]
        public void RecordShouldBeOne()
        {
            var result = Getter(testData);
            Assert.AreEqual(1, result.Count);
        }

    }
}
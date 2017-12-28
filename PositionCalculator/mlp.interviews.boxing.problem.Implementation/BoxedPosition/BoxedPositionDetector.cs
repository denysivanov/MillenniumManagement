using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.BoxedPosition
{
    public class BoxedPositionDetector : IBoxedPositionDetector
    {
        public bool IsBoxedPosition(List<TestRecord> testRecords, TestRecord testRecord)
        {
            //*A trader has long(quantity > 0) and short(quantity < 0) positions for the same symbol at different brokers.
            var trader = testRecord.Trader;
            var symbol = testRecord.Symbol;

            var negativeQuantityRecords = testRecords.Where(x => x.Trader == trader && x.Symbol == symbol && x.Quantity < 0);

            foreach (var record in negativeQuantityRecords)
            {
                var broker = record.Broker;
                var positiveQuantityRecords = testRecords.Where(x => x.Trader == trader && x.Symbol == symbol && x.Quantity > 0);

                if (positiveQuantityRecords.Any(x => x.Broker != broker))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
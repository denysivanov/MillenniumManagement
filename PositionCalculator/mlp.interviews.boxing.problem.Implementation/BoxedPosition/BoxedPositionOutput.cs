using System;
using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.BoxedPosition
{
    public class BoxedPositionOutput : IBoxedPositionOutput
    {
        public List<Interface.Entity.OutputRecord> Get(IEnumerable<Interface.Entity.OutputRecord> convertedRecords)
        {
            var  returnValue = new Dictionary<string, Interface.Entity.OutputRecord>();

            var longPositions = convertedRecords.Where(x => x.Quantity > 0);
            var shortPositioons = convertedRecords.Where(x => x.Quantity < 0);

            foreach (var convertedRecord in convertedRecords)
            {
                var key = Key(convertedRecord);

                if (returnValue.ContainsKey(key))
                    continue;

                var trader = convertedRecord.Trader;
                var symbol = convertedRecord.Symbol;

                var longPosionQuantaty = longPositions.Where(x => x.Trader == trader && x.Symbol == symbol).Sum(y => y.Quantity);
                var shortPosionQuantaty = shortPositioons.Where(x => x.Trader == trader && x.Symbol == symbol).Sum(y => y.Quantity);

                var quantity = Quantity(longPosionQuantaty, shortPosionQuantaty);

                convertedRecord.Quantity = quantity;

                returnValue.Add(key, convertedRecord);
            }

            return returnValue.Values.ToList();
        }

        private int Quantity(int longPosionQuantaty, int shortPosionQuantaty)
        {
            return Math.Min(longPosionQuantaty, Math.Abs(shortPosionQuantaty));
        }


        private string Key(Interface.Entity.OutputRecord convertedRecord)
        {
            return $"{convertedRecord.Trader}|{convertedRecord.Symbol}";
        }
    }
}
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.Utility
{
    public class OutputRecordConverter : IOutputRecordConverter
    {
        public OutputRecord Convert(TestRecord testRecord)
        {
            return new OutputRecord
            {
                Quantity = testRecord.Quantity,
                Symbol = testRecord.Symbol,
                Trader = testRecord.Trader,
            };
        }

        public OutputRecord Convert(string trader, string symbol, int quantity)
        {
            var netPosition = new Interface.Entity.OutputRecord
            {
                Trader = trader,
                Symbol = symbol,
                Quantity = quantity
            };

            return netPosition;
        }
    }
}
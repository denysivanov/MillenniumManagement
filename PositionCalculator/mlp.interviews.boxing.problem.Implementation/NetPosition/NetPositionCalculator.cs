using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.NetPosition
{
    public class NetPositionCalculator : INetPositionCalculator
    {
        public List<Interface.Entity.NetPosition> Calculate(List<TestRecord> testResords)
        {
            var returnResults = new List<Interface.Entity.NetPosition>();

            foreach (var trader in TraderDistinct(testResords))
            {
                foreach (var symbol in TraderSymbolDistinct(testResords, trader))
                {
                    returnResults.Add(NetPosition(testResords, trader, symbol));
                }
            }
            
            return returnResults;
        }

        private static Interface.Entity.NetPosition NetPosition(List<TestRecord> testResords, string trader, string symbol)
        {
            var quantity = Quantity(testResords, trader, symbol);
            var netPosition = new Interface.Entity.NetPosition
            {
                Trader = trader,
                Symbol = symbol,
                Quantity = quantity
            };
            return netPosition;
        }

        private static int Quantity(List<TestRecord> testResords, string trader, string symbol)
        {
            return testResords.Where(x => x.Trader == trader & x.Symbol == symbol).Sum(y => y.Quantity);
        }

        private static IEnumerable<string> TraderSymbolDistinct(List<TestRecord> testResords, string trader)
        {
            return testResords.Where(x => x.Trader == trader).Select(y => y.Symbol).Distinct();
        }

        private static IEnumerable<string> TraderDistinct(List<TestRecord> testResords)
        {
            return testResords.Select(x => x.Trader).Distinct();
        }
    }
}
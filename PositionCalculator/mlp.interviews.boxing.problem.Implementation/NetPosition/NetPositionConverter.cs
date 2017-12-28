using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.NetPosition
{
    public class NetPositionConverter : INetPositionConverter
    {
        private readonly INetPositionCalculator _netPositionCalculator;

        public NetPositionConverter(INetPositionCalculator netPositionCalculator)
        {
            _netPositionCalculator = netPositionCalculator;
        }

        public string[] Converter(List<TestRecord> testResords)
        {
            var netPositions = _netPositionCalculator.Calculate(testResords);
            return Convert(netPositions);
        }

        private static string [] Convert(List<Interface.Entity.NetPosition> netPositions)
        {
            var header = new string [] {"TRADER,SYMBOL,QUANTITY"};
            var records = netPositions.Select(Record).ToArray();
            return header.Concat(records).ToArray();
        }

        private static string Record(Interface.Entity.NetPosition x)
        {
            return $"{x.Trader},{x.Symbol},{x.Quantity}";
        }
    }
}
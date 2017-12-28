using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.Utility
{
    public class FileFormatConverter : IFileFormatConverter
    {
        private readonly INetPositionCalculator _netPositionCalculator;

        public FileFormatConverter(INetPositionCalculator netPositionCalculator)
        {
            _netPositionCalculator = netPositionCalculator;
        }

        public string[] Converter(List<TestRecord> testResords)
        {
            var netPositions = _netPositionCalculator.Calculate(testResords);
            return Convert(netPositions);
        }

        private static string [] Convert(List<OutputRecord> netPositions)
        {
            var header = new[] {"TRADER,SYMBOL,QUANTITY"};
            var records = netPositions.Select(Record).ToArray();
            return header.Concat(records).ToArray();
        }

        private static string Record(Interface.Entity.OutputRecord record)
        {
            return $"{record.Trader},{record.Symbol},{record.Quantity}";
        }
    }
}
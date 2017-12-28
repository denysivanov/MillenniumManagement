using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.Utility
{
    public class FileFormatConverter : IFileFormatConverter
    {
        public string [] Convert(List<OutputRecord> outputRecords)
        {
            var header = new[] {"TRADER,SYMBOL,QUANTITY"};
            var records = outputRecords.Select(Record).ToArray();
            return header.Concat(records).ToArray();
        }

        private static string Record(OutputRecord record)
        {
            return $"{record.Trader},{record.Symbol},{record.Quantity}";
        }
    }
}
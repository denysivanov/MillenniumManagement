using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.Utility
{
    public class RecordConverter : IRecordConverter
    {
        private readonly IFileReader _fileReader;

        public RecordConverter(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public List<TestRecord> GetRecords(string fileName)
        {
            var fileData = _fileReader.GetData(fileName);
            return Convert(fileData);
        }

        private static List<TestRecord> Convert(string[] fileRecords)
        {
            var returnRecords = new List<TestRecord>();

            for (var i = 1; i < fileRecords.Length; i++)
            {
                var records = fileRecords[i].Split(',');
                var record = ConvertRecord(records);
                returnRecords.Add(record);
            }
            return returnRecords;
        }

        private static TestRecord ConvertRecord(string[] records)
        {
            return new TestRecord
            {
                Trader = records[0],
                Broker = records[1],
                Symbol = records[2],
                Quantity = System.Convert.ToInt32(records[3]),
                Price = System.Convert.ToDecimal(records[4]),
            };
        }
    }
}
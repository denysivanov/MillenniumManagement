using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.Utility
{
    public class DataWriter : IDataWriter
    {
        private readonly IFileOperations _fileOperations;
        private readonly IFileFormatConverter _fileFormatConvert;

        public DataWriter(IFileOperations fileOperations, IFileFormatConverter fileFormatConvert)
        {
            _fileOperations = fileOperations;
            _fileFormatConvert = fileFormatConvert;
        }

        public void Write(string fileName, List<OutputRecord> outputRecords)
        {
            var lines = _fileFormatConvert.Convert(outputRecords);
            _fileOperations.Write(fileName, lines);
        }
    }
}
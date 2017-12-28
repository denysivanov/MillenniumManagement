using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.NetPosition
{
    public class NetPositionFile : INetPositionFile
    {
        private readonly IFileFormatConverter _fileFormatConvert;
        private readonly IFileWriter _fileWriter;

        public NetPositionFile(IFileFormatConverter fileFormatConvert, IFileWriter fileWriter)
        {
            _fileFormatConvert = fileFormatConvert;
            _fileWriter = fileWriter;
        }

        public void WriteData(List<TestRecord> testResords, string fileName)
        {
            var lines = _fileFormatConvert.Converter(testResords);
            _fileWriter.Write(fileName, lines);
        }
    }
}
using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.NetPosition
{
    public class NetPositionFile : INetPositionFile
    {
        private readonly INetPositionCalculator _netPositionCalculator;
        private readonly IFileFormatConverter _fileFormatConvert;
        private readonly IFileWriter _fileWriter;

        public NetPositionFile(IFileFormatConverter fileFormatConvert, IFileWriter fileWriter, INetPositionCalculator netPositionCalculator)
        {
            _fileFormatConvert = fileFormatConvert;
            _fileWriter = fileWriter;
            _netPositionCalculator = netPositionCalculator;
        }

        public void WriteData(List<TestRecord> testResords, string fileName)
        {
            var netPositions = _netPositionCalculator.Calculate(testResords);
            var lines = _fileFormatConvert.Convert(netPositions);
            _fileWriter.Write(fileName, lines);
        }
    }
}
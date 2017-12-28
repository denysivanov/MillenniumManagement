using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.NetPosition
{
    public class NetPositionFile : INetPositionFile
    {
        private readonly INetPositionConverter _netPositionConvert;
        private readonly IFileWriter _fileWriter;

        public NetPositionFile(INetPositionConverter netPositionConvert, IFileWriter fileWriter)
        {
            _netPositionConvert = netPositionConvert;
            _fileWriter = fileWriter;
        }

        public void WriteData(List<TestRecord> testResords, string filename)
        {
            var lines = _netPositionConvert.Converter(testResords);
            _fileWriter.Write(filename, lines);
        }
    }
}
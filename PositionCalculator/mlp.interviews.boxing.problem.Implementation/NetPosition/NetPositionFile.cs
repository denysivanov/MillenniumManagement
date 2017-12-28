using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.NetPosition
{
    public class NetPositionFile : INetPositionFile
    {
        private readonly INetPositionCalculator _netPositionCalculator;
        private readonly IDataWriter _dataWriter;

        public NetPositionFile(INetPositionCalculator netPositionCalculator, IDataWriter dataWriter)
        {
            _netPositionCalculator = netPositionCalculator;
            _dataWriter = dataWriter;
        }

        public void WriteData(List<TestRecord> testResords, string fileName)
        {
            var netPositions = _netPositionCalculator.Calculate(testResords);
            _dataWriter.Write(fileName, netPositions);
        }
    }
}
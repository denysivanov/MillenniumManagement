using System;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation
{
    public class Executor : IExecutor
    {
        private readonly IRecordConverter _recordConverter;
        private readonly INetPositionFile _netPositionFile;

        public Executor(IRecordConverter recordConverter, INetPositionFile netPositionFile)
        {
            _recordConverter = recordConverter;
            _netPositionFile = netPositionFile;
        }

        public void Run()
        {
            var testResords = _recordConverter.GetRecords(@"test_data.csv");

            _netPositionFile.WriteData(testResords, @"net_positions.csv");
        }
    }
}
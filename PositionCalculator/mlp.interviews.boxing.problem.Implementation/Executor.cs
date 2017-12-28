using System;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation
{
    public class Executor : IExecutor
    {
        private readonly IRecordConverter _recordConverter;
        private readonly INetPositionFile _netPositionFile;
        private readonly IBoxedPositionFile _boxedPositionFile;

        public Executor(IRecordConverter recordConverter, INetPositionFile netPositionFile, IBoxedPositionFile boxedPositionFile)
        {
            _recordConverter = recordConverter;
            _netPositionFile = netPositionFile;
            _boxedPositionFile = boxedPositionFile;
        }

        public void Run()
        {
            var testResords = _recordConverter.GetRecords(@"test_data.csv");

            _netPositionFile.WriteData(testResords, @"net_positions.csv");
            _boxedPositionFile.WriteData(testResords, @"boxed_positions.csv");
        }
    }
}
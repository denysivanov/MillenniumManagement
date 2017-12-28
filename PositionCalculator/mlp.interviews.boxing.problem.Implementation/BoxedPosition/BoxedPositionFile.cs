using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.BoxedPosition
{
    public class BoxedPositionFile : IBoxedPositionFile
    {
        private readonly IBoxedPositionCalculator _boxedPositionFileFormatConverter;
        private readonly IDataWriter _dataWriter;

        public BoxedPositionFile(IBoxedPositionCalculator boxedPositionFileFormatConverter, IDataWriter dataWriter)
        {
            _boxedPositionFileFormatConverter = boxedPositionFileFormatConverter;
            _dataWriter = dataWriter;
        }

        public void WriteData(List<TestRecord> testResords, string fileName)
        {
            var boxedPositions = _boxedPositionFileFormatConverter.Calculate(testResords);
            _dataWriter.Write(fileName, boxedPositions);
        }
    }
}
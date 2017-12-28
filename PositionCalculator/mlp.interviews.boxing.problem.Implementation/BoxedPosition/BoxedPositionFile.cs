using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.BoxedPosition
{
    public class BoxedPositionFile : IBoxedPositionFile
    {
        private readonly IFileWriter _fileWriter;
        private readonly IBoxedPositionCalculator _boxedPositionFileFormatConverter;

        public BoxedPositionFile(IFileWriter fileWriter, IBoxedPositionCalculator boxedPositionFileFormatConverter)
        {
            _fileWriter = fileWriter;
            _boxedPositionFileFormatConverter = boxedPositionFileFormatConverter;
        }

        public void WriteData(List<TestRecord> testResords, string fileName)
        {
            //var lines = _boxedPositionFileFormatConverter.Calculate(testResords);
            //_fileWriter.Write(fileName, lines);
        }
    }
}
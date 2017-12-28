using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.BoxedPosition
{
    public class BoxedPositionFile : IBoxedPositionFile
    {
        private readonly IFileWriter _fileWriter;
        private readonly IFileFormatConverter _fileFormatConvert;
        private readonly IBoxedPositionCalculator _boxedPositionFileFormatConverter;

        public BoxedPositionFile(IFileWriter fileWriter, IBoxedPositionCalculator boxedPositionFileFormatConverter, IFileFormatConverter fileFormatConvert)
        {
            _fileWriter = fileWriter;
            _boxedPositionFileFormatConverter = boxedPositionFileFormatConverter;
            _fileFormatConvert = fileFormatConvert;
        }

        public void WriteData(List<TestRecord> testResords, string fileName)
        {
            var boxedPositions = _boxedPositionFileFormatConverter.Calculate(testResords);
            var lines = _fileFormatConvert.Convert(boxedPositions);
            _fileWriter.Write(fileName, lines);
        }
    }
}
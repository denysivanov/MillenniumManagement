using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.BoxedPosition
{
    public class BoxedPositionCalculator : IBoxedPositionCalculator
    {
        private readonly IOutputRecordConverter _outputRecordConverter;
        private readonly IBoxedPositionDetector _boxedPositionDetector;
        private readonly IBoxedPositionOutput _boxedPositionOutput;

        public BoxedPositionCalculator(IOutputRecordConverter outputRecordConverter, IBoxedPositionDetector boxedPositionDetector, IBoxedPositionOutput boxedPositionOutput)
        {
            _outputRecordConverter = outputRecordConverter;
            _boxedPositionDetector = boxedPositionDetector;
            _boxedPositionOutput = boxedPositionOutput;
        }

        public List<OutputRecord> Calculate(List<TestRecord> testResords)
        {
             
            var boxedPositions = testResords.Where(x => _boxedPositionDetector.IsBoxedPosition(testResords, x));
            var convertedRecords = boxedPositions.Select(_outputRecordConverter.Convert);
            var returnRecords = _boxedPositionOutput.Get(convertedRecords);

            return returnRecords;
        }
    }
}
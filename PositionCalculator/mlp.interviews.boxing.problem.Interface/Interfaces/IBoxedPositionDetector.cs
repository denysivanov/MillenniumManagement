using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface IBoxedPositionDetector
    {
        bool IsBoxedPosition(List<TestRecord> testRecords, TestRecord testRecord);
    }
}
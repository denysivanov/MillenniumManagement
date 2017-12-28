using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface INetPositionFile
    {
        void WriteData(List<TestRecord> testResords, string filename);
    }
}
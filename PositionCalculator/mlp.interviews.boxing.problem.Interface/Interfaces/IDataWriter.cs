using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface IDataWriter
    {
        void Write(string fileName, List<OutputRecord> outputRecords);
    }
}
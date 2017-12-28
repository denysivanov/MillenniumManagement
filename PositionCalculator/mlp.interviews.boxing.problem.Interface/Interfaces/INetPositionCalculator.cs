using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface INetPositionCalculator
    {
        List<Entity.OutputRecord> Calculate(List<TestRecord> testResords);
    }
}
using System.Collections.Generic;
using mlp.interviews.boxing.problem.Interface.Entity;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface INetPositionCalculator
    {
        List<Entity.NetPosition> Calculate(List<TestRecord> testResords);
    }
}
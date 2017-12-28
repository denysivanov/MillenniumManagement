using System.Collections.Generic;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface IBoxedPositionOutput
    {
        List<Entity.OutputRecord> Get(IEnumerable<Entity.OutputRecord> convertedRecords);
    }
}
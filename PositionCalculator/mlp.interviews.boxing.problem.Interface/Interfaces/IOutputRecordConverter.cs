using mlp.interviews.boxing.problem.Interface.Entity;

namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface IOutputRecordConverter
    {
        OutputRecord Convert(TestRecord testRecord);
        OutputRecord Convert(string trader, string symbol, int quantity);
    }
}
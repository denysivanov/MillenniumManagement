namespace mlp.interviews.boxing.problem.Interface.Interfaces
{
    public interface IFileOperations
    {
        string[] GetData(string fileName);
        void Write(string fileName, string[] lines);
    }
}
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.Utility
{
    public class FileReader : IFileReader
    {
        public string[] GetData(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName);
        }
    }
}
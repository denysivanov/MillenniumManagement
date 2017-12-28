using System;
using System.IO;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.Utility
{
    public class FileWriter : IFileWriter
    {
        public void Write(string fileName, string[] lines)
        {
            Console.WriteLine($"Output fileName ==>>> {Directory.GetCurrentDirectory()}\\{fileName}");
            File.WriteAllLines(fileName, lines);
        }
    }
}
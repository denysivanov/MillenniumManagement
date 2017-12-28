using System;
using mlp.interviews.boxing.problem.Initializer;

namespace mlp.interviews.boxing.problem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var containerInitializer = new ContainerInitializer();
                var executor = containerInitializer.GetExecutor();

                executor.Run();


                Console.WriteLine("-------------------------");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

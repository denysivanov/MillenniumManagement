using System;

namespace SoftwareTest
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var challenges = new IChallenge[]
            {
                new NumberCalculator(),
                new RunLengthEncodingChallenge()
            };

            foreach (var challenge in challenges)
            {
                var challengeName = challenge.GetType().Name;

                var result = challenge.Winner()
                    ? string.Format("You win at challenge {0}", challengeName)
                    : string.Format("You lose at challenge {0}", challengeName);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}

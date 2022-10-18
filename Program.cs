using Newtonsoft.Json;
using static Statistics.Statistics;
namespace Skarp_beskrivande_statistik
{ 
    internal class Program
    {
        static void Main()
        {
            // JSON
            int[] exempelArray = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json.json"));           
           
            Console.WriteLine("Mean: " + Mean(exempelArray));
            Console.WriteLine("Median: " + Median(exempelArray));
            Console.WriteLine("Minimum: " + Minimum(exempelArray));

            Console.ReadKey();
        }
    }
}

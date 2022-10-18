using Newtonsoft.Json;
﻿using static Statistics.Statistics;

namespace Skarp_beskrivande_statistik
{ 
    internal class Program
    {
        static void Main()
        {
            // JSON
            int[] exempelArray = new int[] { 105, 3, 10, 42, 400, 10, 11 };

            for (int i = 0; i < exempelArray.Length; i++)
                Console.Write(exempelArray[i] + " ");
            Console.WriteLine();

            Console.WriteLine("Mean: " + Mean(exempelArray));
            Console.WriteLine("Median: " + Median(exempelArray));
            Console.WriteLine("Minimum: " + Minimum(exempelArray));

            Console.ReadKey();
        }
    }
}

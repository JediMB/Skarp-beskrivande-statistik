﻿using Newtonsoft.Json;
﻿using static Statistics.Statistics;

namespace Skarp_beskrivande_statistik
{ 
    internal class Program
    {
        static void Main()
        {
            // JSON
            int[] exempelArray = new int[] { 105, 10, 3, 42, 400, 10, 11, 3 };

            for (int i = 0; i < exempelArray.Length; i++)
                Console.Write(exempelArray[i] + " ");
            Console.WriteLine();

            Console.WriteLine("Mean: " + Mean(exempelArray));
            Console.WriteLine("Median: " + Median(exempelArray));
            Console.WriteLine("Minimum: " + Minimum(exempelArray));

            Console.Write("Mode: ");
            foreach (int i in Mode(exempelArray))
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }
}

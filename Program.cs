﻿using static Statistics.Statistics;

namespace Skarp_beskrivande_statistik
{ 
    internal class Program
    {
        static void Main()
        {
            int[] source = FileReader.Json();

            foreach (KeyValuePair<string, dynamic> value in DescriptiveStatistics(source))
            {
                Console.Write($"{value.Key.ToString().PadRight(20)}");
                Console.Write($": {value.Value}\n");
            }

            Console.ReadKey();
        }
    }
}

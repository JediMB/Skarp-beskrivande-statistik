using Newtonsoft.Json;
﻿using static Statistics.Statistics;

namespace Skarp_beskrivande_statistik
{ 
    internal class Program
    {
        static void Main()
        {
            // JSON

            int[] source = FileReader.Json();

            for (int i = 0; i < source.Length; i++)
                Console.Write(source[i] + " ");
            Console.WriteLine();

            foreach (dynamic value in DescriptiveStatistics(source))
                Console.WriteLine(value);

            Console.ReadKey();
        }
    }
}

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
                Console.Write($"\n{value.Key.ToString().PadRight(20)}: ");

                if(value.Value is int[])
                {
                    int[] values = (int[])value.Value;
                    Console.Write(values[0]);

                    if (values.Length > 1)
                        for (int i = 1; i < values.Length; i++)
                            Console.Write(", " + values[i]);

                    continue;
                }

                if (value.Value is double)
                {
                    Console.Write($"{value.Value:F1}");
                    continue;
                }

                Console.Write($"{value.Value}");
            }

            Console.ReadKey();
        }
    }
}

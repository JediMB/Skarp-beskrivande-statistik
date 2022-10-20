using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Beskrivande_Statistik
{
    public static class Data
    {
        private static int[]? numbers;
        private static readonly string jsonFilename = @"data.json";

        public static int[] JsonNumbers { get => numbers ??= JsonConvert.DeserializeObject<int[]>(File.ReadAllText(jsonFilename)) ?? Array.Empty<int>(); }


        public static void Print(Func<int[], int> statisticsMethod)
        {
            Console.WriteLine($"\n\n{statisticsMethod.Method.Name,-20}: {statisticsMethod(Data.JsonNumbers)}\n");
        }

        public static void Print(Func<int[], double> statisticsMethod)
        {
            double result = statisticsMethod(Data.JsonNumbers);

            Console.WriteLine($"\n\n{statisticsMethod.Method.Name,-20}: {(Math.Abs(result % 1) <= Double.Epsilon ? result.ToString("F0") : result.ToString("F1"))}\n");
        }

        public static void Print(Func<int[], dynamic> statisticsMethod)
        {
            dynamic result = statisticsMethod(Data.JsonNumbers);


            if (result is Dictionary<string, dynamic>)
            {
                Console.WriteLine("\n\nDescriptive statistics for data.json:");

                foreach (KeyValuePair<string, dynamic> value in result)
                {
                    Console.Write($"\n{value.Key,-20}: ");

                    if (value.Value is int[] values)
                    {
                        PrintArrayValues(values);

                        continue;
                    }

                    if (value.Value is double)
                    {
                        Console.Write($"{(Math.Abs(value.Value % 1) <= Double.Epsilon ? value.Value.ToString("F0") : value.Value.ToString("F1"))}");
                        continue;
                    }

                    Console.Write($"{value.Value}");
                }
                Console.WriteLine("\n");
                return;
            }

            if (result is int[] integers)
            {
                Console.Write($"\n\n{statisticsMethod.Method.Name,-20} :");

                PrintArrayValues(integers);

                Console.WriteLine("\n");
                return;
            }
        }

        private static void PrintArrayValues(int[] values)
        {
            Console.Write(values[0]);

            if (values.Length > 1)
                for (int i = 1; i < values.Length; i++)
                    Console.Write(", " + values[i]);
        }
        
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Xml.Linq;

namespace Beskrivande_Statistik
{
    public static class Data
    {
        private static int[]? numbers;
        private static readonly string jsonFilename = @"data.json";

        public static int[] JsonNumbers { get => numbers ??= JsonConvert.DeserializeObject<int[]>(File.ReadAllText(jsonFilename)) ?? Array.Empty<int>(); }

        #region Public Print Methods
        /// <summary>
        /// Prints the the data from a statistics method that returns an integer value
        /// </summary>
        /// <param name="statisticsMethod">Statistics.Minimum, Statistics.Maximum, or Statistics.Range</param>
        public static void Print(Func<int[], int> statisticsMethod)
        {
            Console.WriteLine($"\n\n{SpacedOutString(statisticsMethod.Method.Name),-20}: {statisticsMethod(Data.JsonNumbers)}\n");
        }

        /// <summary>
        /// Prints the data from a statistics method that returns a double value, with a maximum of one decimal
        /// </summary>
        /// <param name="statisticsMethod">Statistics.Mean, Statistics.Median, or Statistics.StandardDeviation</param>
        public static void Print(Func<int[], double> statisticsMethod)
        {
            double result = statisticsMethod(Data.JsonNumbers);

            Console.WriteLine($"\n\n{SpacedOutString(statisticsMethod.Method.Name),-20}: {(Math.Abs(result % 1) <= Double.Epsilon ? result.ToString("F0") : result.ToString("F1"))}\n");
        }

        /// <summary>
        /// Prints the data from a statistics method that returns a reference type, using aggregation
        /// </summary>
        /// <param name="statisticsMethod">Statistics.DescriptiveStatistics or Statistics.Mode</param>
        /// <param name="aggregate">Set this to true</param>
        public static void Print(Func<int[], dynamic> statisticsMethod, bool aggregate)
        {
            dynamic result = statisticsMethod(Data.JsonNumbers);

            if (result is Dictionary<string, dynamic> dic)
            {
                Console.WriteLine("\n\nDescriptive statistics for data.json:");

                Console.WriteLine(dic.Aggregate(new StringBuilder(),
                    (sb, kvp) => sb.AppendFormat($"\n{kvp.Key,-20}: " +
                    $"{(kvp.Value is int[] array ? string.Join(", ", array.Select(x => x.ToString())) : (kvp.Value is double value ? (value % 1 <= Double.Epsilon ? value.ToString("F0") : value.ToString("F1")) : kvp.Value))}"),
                    sb => sb.ToString()) + "\n");
                return;
            }

            if (result is int[] ints)
            {
                Console.WriteLine($"\n\n{SpacedOutString(statisticsMethod.Method.Name),-20}: " + string.Join(", ", ints.Select(x => x.ToString())) + "\n");
                return;
            }
        }

        /// <summary>
        /// Prints the data from a statistics method that returns a reference type
        /// </summary>
        /// <param name="statisticsMethod">Statistics.DescriptiveStatistics or Statistics.Mode</param>
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
                Console.Write($"\n\n{statisticsMethod.Method.Name,-20}: ");

                PrintArrayValues(integers);

                Console.WriteLine("\n");
                return;
            }
        }
        #endregion

        #region Private Print Helper-Methods
        /// <summary>
        /// Prints all the values in an integer array
        /// </summary>
        private static void PrintArrayValues(int[] values)
        {
            Console.Write(values[0]);

            if (values.Length > 1)
                for (int i = 1; i < values.Length; i++)
                    Console.Write(", " + values[i]);
        }

        /// <summary>
        /// Inserts a blankspace before any uppercase letters after index 0 and returns the new string
        /// </summary>
        private static string SpacedOutString(string text)
        {
            if (text.Length > 1)
                for (int i = 1; i < text.Length; i++)
                {
                    if (Char.IsUpper(text[i]))
                    {
                        text = text[..i] + " " + text[i..];
                        i++;
                    }
                }

            return text;
        }
        #endregion
    }
}

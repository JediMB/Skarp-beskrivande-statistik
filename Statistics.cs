using System.Security.Cryptography.X509Certificates;

namespace Statistics
{
    public static class Statistics
    {

        // public static DescriptiveStatistics(int[] source) : dynamic          
        // public static Maximum(int[] source) : int                            GUSTAV

        public static double Mean(int[] source)                                 // MATTIAS
        {
            VerifySource(source);

            double sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum / source.Length;
        }

        public static double Median(int[] source)                               // ERIK
        {
            VerifySource(source);

            Array.Sort(source);
            int halfLength = source.Length / 2;

            if (source.Length % 2 == 0)
            {
                double middle1 = source[halfLength - 1];
                double middle2 = source[halfLength];
                return (middle1 + middle2) / 2;
            }

            return source[halfLength];
        }

        public static int Minimum(int[] source)                                 // TOVA
        {
            VerifySource(source);
            return source.Min();
        }

        // public static Mode(int[] source) : int[]                             
        // public static Range(int[] source) : int                              
        // public static StandardDeviation(int[] source) : double

        public static int Maximum(int[] source)                         //Gustav
        {
            VerifySource(source);
            int Maximum = source.Max();
            return Maximum;
        }
        public static int Range(int[] source)                           //Gustav
        {
            VerifySource(source);
            int range = source.Max() - source.Min();
            return range;
        }

        public static double StandardDeviation(int[] source)          //Gustav
        {
            VerifySource(source);
            double savg = 0;
            double count = source.Count();
            double standardDeviavrg = source.Average();
            double standardDevisum = source.Sum(i => (i - standardDeviavrg) * (i - standardDeviavrg));
            savg = Math.Sqrt(standardDevisum / count);
            return savg;
        }

        private static void VerifySource(int[] source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                throw new ArgumentException("Array is empty", nameof(source));

        }
        public static int[] Mode(int[] source)
        {
            VerifySource(source);

            Dictionary<int, int> values = new();

            for (int i = 0; i < source.Length; i++)
            {
                if (values.ContainsKey(source[i]))
                    values[source[i]]++;
                else
                    values.Add(source[i], 1);
            }

            int maxCount = values.Values.Max();

            foreach (KeyValuePair<int, int> kvp in values)
            {
                if (kvp.Value != maxCount)
                    values.Remove(kvp.Key);
            }

            return values.Keys.ToArray();

        }
    }
}

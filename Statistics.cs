namespace Statistics
{
    public static class Statistics
    {
        // public static DescriptiveStatistics(int[] source) : dynamic          
        // public static Maximum(int[] source) : int                            GUSTAV
        // public static Mean(int[] source) : double                            MATTIAS
        // public static Median(int[] source) : double                          ERIK
        // public static Minimum(int[] source) : int                            TOVA
        // public static Mode(int[] source) : int[]                             
        // public static Range(int[] source) : int                              
        // public static StandardDeviation(int[] source) : double
        // 

        public static int Maximum(int[] source)                         //Gustav
        {
            int Maximum = source.Max();
            return Maximum;
        }
        public static int Range(int[] source)                           //Gustav
        {
            
            int range = source.Max() - source.Min();
            return range;
        }

        public static double StandardDeviation(int[] source)          //Gustav
        {
            double savg = 0;
            double count = source.Count();
            double standardDeviavrg = source.Average();
            double standardDevisum = source.Sum(i => (i - standardDeviavrg) * (i - standardDeviavrg));
            savg = Math.Sqrt(standardDevisum / count);
            return savg;
        }
    }
}

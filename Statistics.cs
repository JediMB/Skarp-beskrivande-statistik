namespace Statistics
{
    public static class Statistics
    {
        public static double Median(int[] source)
        {
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
    }
}

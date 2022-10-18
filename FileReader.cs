using Newtonsoft.Json;

namespace Skarp_beskrivande_statistik
{
    public static class FileReader
    {
        public static int[] Json()
        {
            int[]? source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json")) ?? Array.Empty<int>();

            return source;
        }
        
             
    }
}

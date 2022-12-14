namespace Beskrivande_Statistik
{ 
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Descriptive Statistics";

            MainLoop();

            Console.Write("\n\nGood bye!");
            Thread.Sleep(1000);
        }

        static void MainLoop()
        {
            while (true)
            {
                Console.Write("How do you want to math today?" +
                "\n1. Minimum             2. Maximum" +
                "\n3. Mean                4. Median" +
                "\n5. Mode                6. Range" +
                "\n7. Standard Deviation  8. Sum" +
                "\n9. Complete summary" +
                "\n0. EXIT" +
                "\n> ");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Data.Print(Statistics.Minimum);
                        break;

                    case '2':
                        Data.Print(Statistics.Maximum);
                        break;

                    case '3':
                        Data.Print(Statistics.Mean);
                        break;

                    case '4':
                        Data.Print(Statistics.Median);
                        break;

                    case '5':
                        Data.Print(Statistics.Mode, true);
                        break;

                    case '6':
                        Data.Print(Statistics.Range);
                        break;

                    case '7':
                        Data.Print(Statistics.StandardDeviation);
                        break;

                    case '8':
                        Data.Print(Statistics.Sum);
                        break;

                    case '9':
                        Data.Print(Statistics.DescriptiveStatistics, true);
                        break;

                    case '0':
                        return;

                    default:
                        Console.Clear();
                        continue;
                }

                Console.Write("Press the space key to continue... ");
                while(Console.ReadKey(true).KeyChar != ' ') { }
                Console.Clear();
            }
        }
    }
}

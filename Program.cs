namespace Beskrivande_Statistik
{ 
    internal class Program
    {
        static readonly string[] car = new string[]
        {
            @"",
            @"                                                   *%%%%%%       &&&&&&&*",
            @"                                                   %#./,..%    &@&&&&&&&&/      ",
            @"                                                   #(,&,/%#.   ..&@,/&&&&&      ",
            @"                                                    *..,*.(     (.../...*/#,    ",
            @"                                                    @/./,,&%  .%@#...,....(..*  ",
            @"                                              .%%%&%(.%,,&%&%*(%..( /./........ ",
            @"((///*,............,,,.,////*.        . .*//#&@&%%%.,%%.%%@%%&(*&%  ......./....",
            @"///////////*(,......*%&&%(#%%%((###((((#%%%%%%&%%&&.#%.%%%%%&../.& ........./...",
            @"//////(....%%%*%*************////#%#%////////&&&&%&%%,%&%%%%&&*..,.........(,,,.",
            @"/#...(%&///%/#/***************/(..*.&(////&%%&&&%%%%%@%%%%%%&@&*,.....,*(,,,,,..",
            @".%&(****/((#////*/***************%%#**,%%&&&&&&&%&@%%%%%%%%%&&.....,*/(,,,......",
            @"******/%#%//////////*************/####/////////%%%#.....%%%%&& ..**#,,,,.,,.....",
            @",,*/&%*###,,,,,...*(/************/#%&%%%%#/*..%%*,/**#&@&&&&&&&&@,,...,,,,,,,...",
            @"#%%%/%#%#,,,,,,,,,,,%#(,.....................&%%%&%%%%%&&&&&@...(.,,,,,,,,,.....",
            @"/,/%%(,.(.(/**.......................,......&%%%%%@%%%%%%%%%&.,.&,,,,*******/**/",
            @".......*/.,(,...............,.,(*#.,.*......%%%&&&%%%%%%%%%%@,,,,,&%%%&@@@%%%%%%",
            @"...........................,.(#(/,#,,#.....%&&&&&&&&%%%%%%%%@*,,,,%%%%%%%%%%%%%%"
        };

        static void Main()
        {
            Console.Title = "Descriptive Statistics";

            foreach (string line in car)
                Console.WriteLine(line);

            Console.WriteLine("\n*slaps roof of car*\nThis bad boy can fit so many numbers in it.");

            MainLoop();

            Console.Write("\n\nPress any key to exit... ");
            Console.ReadKey();
        }

        static void MainLoop()
        {
            while (true)
            {
                Console.Write("How do you want to math today?" +
                "\n1. Minimum 2. Maximum" +
                "\n3. Mean    4. Median" +
                "\n5. Mode    6. Range" +
                "\n7. Standard Deviation" +
                "\n8. Hit me with everything!" +
                "\n0. Just let me go..." +
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
                        Data.Print(Statistics.Mode);
                        break;

                    case '6':
                        Data.Print(Statistics.Range);
                        break;

                    case '7':
                        Data.Print(Statistics.StandardDeviation);
                        break;

                    case '8':
                        Data.Print(Statistics.DescriptiveStatistics);
                        break;

                    case '0':
                        return;

                    default:
                        Console.Clear();
                        continue;
                }

                Console.Write("Press any key to continue... ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

using System;
using Microsoft.Extensions.DependencyInjection;

using HOB.Services;

namespace HOB
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
           //.AddLogging()
            .AddScoped<ICleaningService, CleaningService>()
            .AddScoped<IParsingService, ParsingService>()
            .AddScoped<IFileService, FileService>()
            .AddScoped<IBigramService, BigramService>()
            .AddScoped<IHistogramService, HistogramService>()
            .AddScoped<IReportService<BigramHistogramReport>, BigramHistogramReportService>()
            .AddScoped<IHobHelper, HobHelper>()
            .BuildServiceProvider();

            var helper = serviceProvider.GetService<IHobHelper>();

            Console.WriteLine("Welcome to HOB.");
            Console.WriteLine("---------------");
            Console.WriteLine("");
            Console.WriteLine("This application accepts a text input and generates a histogram of the bigrams found in the text.");
            Console.WriteLine("Please specify the method you wish to provide text:");
            Console.WriteLine("");
            Console.WriteLine("Press 'F' key to specify a file containing the text.");
            Console.WriteLine("Press any other key to use the application interactively.");

            string choice = Console.ReadLine();

            if (choice.ToUpper() == "F")
            {
                Console.WriteLine("");
                Console.WriteLine("Enter filename containing text:");
                Console.WriteLine("");

                string filename = Console.ReadLine();

                var consoleOutput = helper.GetHobForConsoleFromFile(filename);

                Console.WriteLine("");
                Console.WriteLine("========================================================================================");

                foreach (var outputline in consoleOutput)
                {
                    Console.WriteLine(outputline);
                }
                Console.WriteLine("========================================================================================");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Enter text and hit the enter key to generate a Histogram.  Enter 'X' to exit.");
                    Console.WriteLine("");

                    string text = Console.ReadLine();

                    if (text.ToUpper() == "X")
                    {
                        return;
                    }

                    var consoleOutput = helper.GetHobForConsole(text);

                    Console.WriteLine("");
                    Console.WriteLine("========================================================================================");

                    foreach (var outputline in consoleOutput)
                    {
                        Console.WriteLine(outputline);
                    }
                    Console.WriteLine("========================================================================================");
                }
            }

            
       
        }
    }
}

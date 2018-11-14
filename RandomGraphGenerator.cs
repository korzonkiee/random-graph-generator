using System;
using System.IO;

namespace RandomGraphGenerator
{
    public class RandomGraphGenerator
    {
        private string outputDir;
        private int numberOfExamples;
        private int minimalGraphSize;
        private int maximalGraphSize;

        public RandomGraphGenerator(string outputDir, int numberOfExamples, int minimalGraphSize, int maximalGraphSize)
        {
            this.outputDir = outputDir;
            this.numberOfExamples = numberOfExamples;
            this.minimalGraphSize = minimalGraphSize;
            this.maximalGraphSize = maximalGraphSize;
        }

        public void Generate()
        {
            CreateOutputDir();

            for (int i = 0; i < numberOfExamples; i++)
            {

            }
        }

        private void CreateOutputDir()
        {
            if (Directory.Exists(outputDir))
            {
                Console.Write($"Directory {outputDir} already exists. Do you want to remove it? [y/n] ");
                var response = Console.ReadKey(false).Key;
                if (Console.ReadKey(false).Key == ConsoleKey.Enter)
                {
                    if (response == ConsoleKey.Y)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Removing {outputDir} directory.");
                        try
                        {
                            Directory.Delete(outputDir);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error occured while removing {outputDir} directory.");
                            Console.WriteLine(ex.StackTrace);

                            Environment.Exit(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Exitting.");
                        Environment.Exit(1);
                    }
                }
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(outputDir);
                    Environment.CurrentDirectory = outputDir;

                    Console.WriteLine(Environment.CurrentDirectory);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured while creating directory {outputDir}");
                    Console.WriteLine(ex.StackTrace);

                    Environment.Exit(1);
                }
            }
        }
    }
}
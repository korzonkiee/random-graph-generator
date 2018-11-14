using System;
using System.Collections.Generic;
using CommandLine;

namespace RandomGraphGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<ProgramArguments>(args)
                .WithParsed<ProgramArguments>(opts => Run(opts));
        }

        static void Run(ProgramArguments args)
        {
            if (args.NumberOfExamples < 1)
            {
                Console.WriteLine($"Number of examples must be greater that 0.");
                return;
            }

            if (args.MinimalSize < 1)
            {
                Console.WriteLine($"Minimal graph size must be greater that 0.");
                return;
            }

            if (args.MaximalSize < 1 || args.MaximalSize < args.MinimalSize)
            {
                Console.WriteLine($"Maximal graph size must be greater that 0 and greater or equal than minimal graph size.");
                return;
            }

            if (args.EdgeProbability < 0 || args.EdgeProbability > 100)
            {
                Console.WriteLine($"Edge probability must be value between 0 and 100");
                return;
            }

            new RandomGraphGenerator(args.OutputDir, args.NumberOfExamples,
                    args.MinimalSize, args.MaximalSize, args.EdgeProbability)
                .Generate();
        }
    }
}
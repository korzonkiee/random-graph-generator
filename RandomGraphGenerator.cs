using System;
using System.IO;
using RandomGraphGenerator.Utils;

namespace RandomGraphGenerator
{
    public class RandomGraphGenerator
    {
        private string outputDir;
        private int numberOfExamples;
        private int minGraphSize;
        private int maxGraphSize;

        private readonly DirectoryCreator directoryCreator = new DirectoryCreator();
        private readonly RandomGraphCreator randomGraphCreator = new RandomGraphCreator();

        public RandomGraphGenerator(string outputDir, int numberOfExamples, int minimalGraphSize, int maximalGraphSize)
        {
            this.outputDir = outputDir;
            this.numberOfExamples = numberOfExamples;
            this.minGraphSize = minimalGraphSize;
            this.maxGraphSize = maximalGraphSize;
        }

        public void Generate()
        {
            if (!directoryCreator.SafelyCreate(outputDir))
            {
                Environment.Exit(1);
            }
            else
            {
                Environment.CurrentDirectory = outputDir;
            }

            for (int i = 0; i < numberOfExamples; i++)
            {
                string exampleDir = $"{i + 1}";
                if (!directoryCreator.SafelyCreate(exampleDir))
                {
                    Environment.Exit(1);
                }
                else
                {
                    var graphA = randomGraphCreator.GenerateRandomGraph(minGraphSize, maxGraphSize);
                    var graphB = randomGraphCreator.GenerateRandomGraph(graphA.Size, maxGraphSize);

                    string graphAFile = $"{graphA.Size}_{graphB.Size}_A_{Config.ExampleFileKey}.csv";
                    string graphBFile = $"{graphA.Size}_{graphB.Size}_B_{Config.ExampleFileKey}.csv";

                    graphA.WriteToFile(Path.Join(exampleDir, graphAFile));
                    graphB.WriteToFile(Path.Join(exampleDir, graphBFile));
                }
            }
        }
    }
}
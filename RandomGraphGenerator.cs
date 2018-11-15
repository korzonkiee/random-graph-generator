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
        private int edgeProbability;

        private readonly DirectoryCreator directoryCreator = new DirectoryCreator();
        private readonly RandomGraphCreator randomGraphCreator = new RandomGraphCreator();

        public RandomGraphGenerator(string outputDir, int numberOfExamples,
            int minimalGraphSize, int maximalGraphSize, int edgeProbability)
        {
            this.outputDir = outputDir;
            this.numberOfExamples = numberOfExamples;
            this.minGraphSize = minimalGraphSize;
            this.maxGraphSize = maximalGraphSize;
            this.edgeProbability = edgeProbability;
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
                    var graph1 = randomGraphCreator.GenerateRandomGraph(minGraphSize, maxGraphSize, edgeProbability);
                    var graph2 = randomGraphCreator.GenerateRandomGraph(minGraphSize, maxGraphSize, edgeProbability);

                    Graph graphA, graphB;
                    if (graph1.Size > graph2.Size)
                    {
                        graphB = graph1;
                        graphA = graph2;
                    }
                    else
                    {
                        graphB = graph2;
                        graphA = graph1;
                    }

                    string graphAFile = $"{graphA.Size}_{graphB.Size}_A_{Config.ExampleFileKey}.csv";
                    string graphBFile = $"{graphA.Size}_{graphB.Size}_B_{Config.ExampleFileKey}.csv";

                    graphA.WriteToFile(Path.Join(exampleDir, graphAFile));
                    graphB.WriteToFile(Path.Join(exampleDir, graphBFile));
                }
            }
        }
    }
}
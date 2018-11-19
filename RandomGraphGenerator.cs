using System;
using System.IO;
using RandomGraphGenerator.Utils;

namespace RandomGraphGenerator
{
    public class RandomGraphGenerator
    {
        private readonly string outputDir;
        private readonly int numberOfExamples;
        private readonly int minGraphSize;
        private readonly int maxGraphSize;
        private readonly int edgeProbability;
        private readonly bool iterate;

        private readonly DirectoryCreator directoryCreator = new DirectoryCreator();
        private readonly RandomGraphCreator randomGraphCreator = new RandomGraphCreator();

        public RandomGraphGenerator(string outputDir, int numberOfExamples,
            int minimalGraphSize, int maximalGraphSize, int edgeProbability,
            bool iterate)
        {
            this.outputDir = outputDir;
            this.numberOfExamples = numberOfExamples;
            this.minGraphSize = minimalGraphSize;
            this.maxGraphSize = maximalGraphSize;
            this.edgeProbability = edgeProbability;
            this.iterate = iterate;
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

            if (iterate)
            {
                for (int size = minGraphSize; size <= maxGraphSize; size += 1)
                {
                    for (int innerSize = minGraphSize; innerSize <= size; innerSize += 1)
                    {
                        string exampleDir = $"{innerSize}_{size}";
                        if (!directoryCreator.SafelyCreate(exampleDir))
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            var graph1 = randomGraphCreator.GenerateGraphOfSize(size, edgeProbability);
                            var graph2 = randomGraphCreator.GenerateGraphOfSize(innerSize, edgeProbability);

                            SaveGraphsToDir(exampleDir, graph1, graph2);
                        }
                    }
                }
            }
            else
            {

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

                        SaveGraphsToDir(exampleDir, graph1, graph2);
                    }
                }
            }
        }

        private void SaveGraphsToDir(string dir, Graph graph1, Graph graph2)
        {
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

            graphA.WriteToFile(Path.Join(dir, graphAFile));
            graphB.WriteToFile(Path.Join(dir, graphBFile));
        }
    }
}
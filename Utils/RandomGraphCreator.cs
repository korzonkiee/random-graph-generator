using System;

namespace RandomGraphGenerator.Utils
{
    public class RandomGraphCreator
    {
        private readonly Random random = new Random();
        public Graph GenerateRandomGraph(int minSize, int maxSize, int edgeProbability)
        {
            int randomSize = random.Next(minSize, maxSize + 1);
            return Graph.Random(randomSize, edgeProbability);
        }

        public Graph GenerateGraphOfSize(int size, int edgeProbability)
        {
            return Graph.Random(size, edgeProbability);
        }
    }
}
using System;

namespace RandomGraphGenerator.Utils
{
    public class RandomGraphCreator
    {
        private readonly Random random = new Random();
        public Graph GenerateRandomGraph(int minSize, int maxSize)
        {
            int randomSize = random.Next(minSize, maxSize + 1);
            return Graph.Random(randomSize);
        }
    }
}
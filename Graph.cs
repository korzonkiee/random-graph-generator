using System;
using System.IO;

namespace RandomGraphGenerator
{
    public class Graph
    {
        public int Size { get; private set; }
        public byte[, ] AdjacencyMatrix { get; private set; }

        private const byte edge = 1;
        private const byte noEdge = 0;

        private Graph(int size, byte[, ] adjacencyMatrix)
        {
            Size = size;
            AdjacencyMatrix = adjacencyMatrix;
        }

        public static Graph Random(int size, int edgeProbability)
        {
            return new Graph(size, RandomizedAdjacencyMatrix(size, edgeProbability));
        }

        private static byte[, ] RandomizedAdjacencyMatrix(int size, int edgeProbability)
        {
            var random = new Random();
            var adjacencyMatrix = new byte[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 1 + row; col < size; col++)
                {
                    byte randEdge = random.NextDouble() < (edgeProbability / 100f) ? edge : noEdge;
                    adjacencyMatrix[row, col] = randEdge;
                    adjacencyMatrix[col, row] = randEdge;
                }
            }

            return adjacencyMatrix;
        }

        public void WriteToFile(string fileName)
        {
            if (Size < 1 || AdjacencyMatrix == null)
            {
                throw new InvalidOperationException($"Cannot write to file {fileName} because graph is not initialized.");
            }

            try
            {
                using(var file = File.CreateText(fileName))
                {
                    for (int row = 0; row < Size; row++)
                    {
                        for (int col = 0; col < Size; col++)
                        {
                            file.Write(AdjacencyMatrix[row, col]);
                            if (col < Size - 1)
                            {
                                file.Write(',');
                            }
                        }
                        file.Write(Config.LineEnding);
                    }

                    Console.WriteLine($"Created graph file {fileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while creating file {fileName}");
                throw ex;
            }
        }
    }
}
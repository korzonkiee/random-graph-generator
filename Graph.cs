using System;
using System.IO;

namespace RandomGraphGenerator
{
    public class Graph
    {
        public int Size { get; private set; }
        public byte[, ] AdjacencyMatrix { get; private set; }

        private Graph(int size, byte[, ] adjacencyMatrix)
        {
            Size = size;
            AdjacencyMatrix = adjacencyMatrix;
        }

        public static Graph Random(int size)
        {
            return new Graph(size, RandomizedAdjacencyMatrix(size));
        }

        private static byte[, ] RandomizedAdjacencyMatrix(int size)
        {
            return new byte[size, size];
        }

        public void WriteToFile(string fileName)
        {
            if (Size < 1 || AdjacencyMatrix == null)
            {
                throw new InvalidOperationException($"Cannot write to file {fileName} because graph is not initialized.");
            }

            Console.WriteLine($"Writing graph to {fileName}");

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
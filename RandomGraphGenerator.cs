namespace RandomGraphGenerator
{
    public class RandomGraphGenerator
    {
        public int NumberOfExamples { get; private set; }
        public int MinimalGraphSize { get; private set; }
        public int MaximalGraphSize { get; private set; }

        public RandomGraphGenerator(int numberOfExamples, int minimalGraphSize, int maximalGraphSize)
        {
            NumberOfExamples = numberOfExamples;
            MinimalGraphSize = minimalGraphSize;
            MaximalGraphSize = maximalGraphSize;
        }
    }
}
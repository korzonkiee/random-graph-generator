using CommandLine;

namespace RandomGraphGenerator
{
    public class ProgramArguments
    {
        [Option('o', "output", Required = false, Default = "examples", HelpText = "Output directory.")]
        public string OutputDir { get; set; }

        [Option('n', "numberOfExamples", Required = true, HelpText = "Number of examples to generate.")]
        public int NumberOfExamples { get; set; }

        [Option('l', "minimalSize", Required = true, HelpText = "Minimal graph size.")]
        public int MinimalSize { get; set; }

        [Option('h', "maximalSize", Required = true, HelpText = "Maximal graph size.")]
        public int MaximalSize { get; set; }

        [Option('d', "edgeProbability", Required = false, HelpText = "Percentage probability of edge between two vertices (0 - 100).")]
        public int EdgeProbability { get; set; }

        [Option('i', "iterate", Required = false, HelpText = "Iterates from minimal size to maximal size and creates one example per size.")]
        public bool Iterate { get; set; }
    }
}
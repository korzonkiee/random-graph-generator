using CommandLine;

namespace RandomGraphGenerator
{
    public class ProgramArguments
    {
        [Option('o', "output", Required = false, Default = "examples", HelpText = "Output directory")]
        public string OutputDir { get; set; }

        [Option('n', "numberOfExamples", Required = true, HelpText = "Number of examples to generate.")]
        public int NumberOfExamples { get; set; }

        [Option('l', "minimalSize", Required = true, HelpText = "Minimal graph size.")]
        public int MinimalSize { get; set; }

        [Option('h', "maximalSize", Required = true, HelpText = "Maximal graph size.")]
        public int MaximalSize { get; set; }
    }
}
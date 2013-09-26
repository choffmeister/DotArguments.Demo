using System;
using System.Text;
using DotArguments;
using DotArguments.Attributes;

namespace DotArgumentsDemo
{
    public class ArgumentContainer
    {
        [PositionalValueArgument(0, "inputpath")]
        [ArgumentDescription(Short = "the input path")]
        public string InputPath { get; set; }

        [PositionalValueArgument(1, "outputpath", IsOptional = true)]
        [ArgumentDescription(Short = "the output path")]
        public string OutputPath { get; set; }

        [NamedSwitchArgument("verbose", 'v')]
        [ArgumentDescription(Short = "toggles verbosity (optional)")]
        public bool Verbose { get; set; }

        [NamedValueArgument("cores", 'c')]
        [ArgumentDescription(Short = "number of CPU cores")]
        public int CPUCoreCount { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // create container definition and the parser
            var definition = new ArgumentDefinition(typeof(ArgumentContainer));

            // choose parser
            var parser = new GNUArgumentParser();

            try
            {
                // create object with the populated arguments
                var arguments = parser.Parse<ArgumentContainer>(definition, args);

                // TODO: print arguments values
            }
            catch (Exception ex)
            {
                // write error message
                Console.Error.WriteLine(string.Format("error: {0}", ex.Message));

                // write help an available arguments
                Console.Error.WriteLine(string.Format("usage: {0}", parser.GenerateUsageString(definition)));
            }

            Console.ReadKey(false);
        }
    }
}
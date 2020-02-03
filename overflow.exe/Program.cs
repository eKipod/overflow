using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;

namespace overflow.exe
{
    public class Options
    {
        [Option('r', "row", Required = true, HelpText = "Row for which to calculate volume (first row is 0).")]
        public uint Row { get; set; }

        [Option('i', "index", Required = true, HelpText = "Index of the glass in the row for which to calculate volume (first index is 0).")]
        public uint Index { get; set; }

        [Option('p', "poured", Required = true, HelpText = "Amount poured (in liters) to the top of the glass pyramid.")]
        public uint Poured { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples { get; } = new[]
        {
            new Example("Calculate the volume of a glass in a glass pyramid", new Options { Row = 3, Index = 2, Poured = 10 } ),
        };
    }


    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    var calculator = new Calculator();
                    var result = calculator.GetVolume(o.Row, o.Index, o.Poured);

                    Console.WriteLine($"{result.Volume} liters");
                });
        }
    }
}

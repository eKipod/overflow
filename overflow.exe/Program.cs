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
        public decimal Poured { get; set; }

        [Option('v', "verbose", Required = false, Default = false, HelpText = "Show all the glasses leading to the result.")]
        public bool Verbose { get; set; }

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
                    var glassFactory = new FixedCapacityGlassFactory(0.25m);
                    var calculator = new Calculator(glassFactory);
                    
                    var result = calculator.GetVolume(o.Row, o.Index, o.Poured);
                    if (o.Verbose)
                    {
                        foreach(var glass in result.Glasses)
                        {
                            if (glass.Index == 0)
                            {
                                Console.WriteLine();
                                Console.Write($"Row {glass.Row}:");
                            }

                            Console.Write($" [Fill: {glass.Fill} Spill: {glass.Spill}]");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"{result.Volume} liters");
                });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Methods
{
    class Program
    {
        private const string _separator = " ";
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert any prase separated by empty space: \" \"");
            var line = Console.ReadLine();
            var lines = SplitLine(line);
            WriteLines(lines);

            Console.WriteLine();

            var reverseLines = Reverse(line);
            WriteLines(reverseLines);
        }

        private static IEnumerable<string> SplitLine(string line)
        {
            return line.Split(_separator);
        }

        private static void WriteLines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static IEnumerable<string> Reverse(string line)
        {
            return SplitLine(line).Reverse();
        }
    }
}

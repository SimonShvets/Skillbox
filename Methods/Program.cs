using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Methods
{
    class Program
    {
        private const string _separator = " ";
        static void Main(string[] args)
        {
            Console.WriteLine($"Please insert any prase separated by: \"{_separator}\"");
            var line = Console.ReadLine();
            var lines = SplitLine(line);
            WriteLines(lines);

            Console.WriteLine();

            var reverseLine = Reverse(line);
            Console.WriteLine(reverseLine);
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

        private static string Reverse(string line)
        {
            var reversedLines = SplitLine(line).Reverse();

            var sb = new StringBuilder();
            return sb.AppendJoin(_separator, reversedLines).ToString();
        }
    }
}

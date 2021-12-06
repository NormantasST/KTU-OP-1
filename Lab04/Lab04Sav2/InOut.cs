using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab04Sav2
{
    static class InOut
    {
        public static void Process(string fin, string fout)
        {
            string text = File.ReadAllText(fin, Encoding.UTF8);
            using (var writer = File.CreateText(fout))
            {

                text = RemoveExtendedComments(text);
                foreach (string line in text.Split('\n'))
                {
                    writer.WriteLine(RemoveRegularComments(line));
                }
            }
        }

        private static string RemoveExtendedComments(string text)
        {
            string newText = Regex.Replace(text, @"\/\*(.|[\r\n])*?\*\/", "",RegexOptions.ECMAScript) ;

            return newText;
        }

        private static string RemoveRegularComments(string line)
        {
            string newLine = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    newLine = line.Remove(i);
                    return newLine;
                }
            }
            return newLine;
        }

        public static bool RemoveComments(string line, out string newLine)
        {
            newLine = RemoveRegularComments(line);
            if (newLine != line)
                return true;
            return false;
        }
    }
}

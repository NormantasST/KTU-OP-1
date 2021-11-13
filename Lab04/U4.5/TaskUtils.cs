using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4._5
{
    static class TaskUtils
    {
        public static void ProcessLine(string line, string fout, string punctuation,
                                   string name, string surname)
        {
            StringBuilder newLine = new StringBuilder();
            AddSurname(line, punctuation, name, surname, newLine);
            Console.WriteLine(newLine);
        }

        public static void Process(string fin, string fout, string punctuation,
                                   string name, string surname)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writer = File.CreateText(fout))
            {
                foreach (string line in lines)
                {
                    StringBuilder newLine = new StringBuilder();
                    AddSurname(line, punctuation, name, surname, newLine);
                    writer.WriteLine(newLine);
                }
            }
        }


        private static void AddSurname(string line, string punctuation, 
                                       string name, string surname, StringBuilder newLine)
        {
            string addLine = " " + line + " ";
            int init = 1;
            int ind = addLine.IndexOf(name);
            while (ind != -1)
            {
                if (punctuation.IndexOf(addLine[ind - 1]) != -1
                && punctuation.IndexOf(addLine[ind + name.Length]) != -1)
                {
                    newLine.Append(addLine.Substring(init, ind + name.Length -
                   init));
                    newLine.Append(" " + surname);
                    init = ind + name.Length;
                }
                ind = addLine.IndexOf(name, ind + 1);
            }
            newLine.Append(line.Substring(init - 1));
        }


    }
}

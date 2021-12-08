using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04Sav4
{
    static class InOut
    {
        public static List<string> ReadLines(string input) => new List<string>(File.ReadAllLines(input));

        public static void WriteLines(string[] lines, string output)
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }         
        }
        
    }
}

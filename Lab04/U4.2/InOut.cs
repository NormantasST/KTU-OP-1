using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U4._2
{
    static class InOut
    {
        public static List<int> LongestLine(string fin)
        {
            List<int> output =  new List<int>();
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int length = 0;
                int lineNo = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > length)
                    {
                        length = line.Length;
                        output.Clear();
                    }
                    if (line.Length == length)
                        output.Add(lineNo);
                    lineNo++;
                }
            }
            return output;
        }

        public static void RemoveLine(string fin, string fout, List<int> No)
        {
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;

                using (var writer = File.CreateText(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (No.Contains(lineNo) == false)
                        {
                            writer.WriteLine(line);
                        }
                        lineNo++;
                    }
                }
            }
        }
    }

}

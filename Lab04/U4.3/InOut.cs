using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4._3
{
    static class InOut
    {
        public static void Process(string fin, string fout, string finfo)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {
                    bool comment = false;
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string newLine = line;
                            if (RemoveComments(line, out newLine, ref comment))
                                writerI.WriteLine(line);
                            if (newLine.Length > 0)
                                writerF.WriteLine(newLine);
                        }
                        else if (comment == false)
                            writerF.WriteLine(line);
                    }
                }
            }
        }

        public static bool RemoveComments(string line, out string newLine, ref bool comment)
        {
            newLine = line;
            bool output = false;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '*')
                    comment = true;
                
                if(comment == true)
                {
                    int endIndex = line.IndexOf("*/");
                    if (endIndex == -1)
                    {
                        // Removes the whole line
                        newLine = line.Remove(i);
                        return true;
                    }
                    else if(endIndex != -1)
                    {
                        endIndex = endIndex + 2;
                        newLine = line.Remove(i, endIndex - i);
                        comment = false;
                        output = true;
                    }
                    
                }

                if (line[i] == '/' && line[i + 1] == '/' && comment == false)
                {
                    newLine = line.Remove(i);
                    return true;
                }
            }
            return output;
        }
        

    }


}

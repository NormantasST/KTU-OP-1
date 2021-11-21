using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04Sav2
{
    static class InOut
    {
        public static void Process(string fin, string fout)
        {
            string text = File.ReadAllText(fin);
            bool isComment = false;
            bool isString = false;
            
            // Removes comments
            for (int i = 0; i < text.Length; i++)
            {
                // Start of String
                if (isString == false && isComment == false && text[i] == '\"' && text[i - 1] != '\\')
                {
                    isString = true;
                    continue;
                } 
                // End of String
                if (isString == true && text[i] == '\"' && text[i - 1] != '\\')
                    isString = false;

                // Start of multiline comment
                if (isComment == false && isString == false && text[i] == '/' && text[i+1] == '*')
                    isComment = true;

                // end of multilinecomment
                if (isComment == true && text[i] == '*' && text[i + 1] == '/')
                {
                    // removes */
                    text = text.Remove(i, 2);
                    i--;
                    isComment = false;
                }

                // removes current element
                if (isComment == true)
                {
                    text = text.Remove(i,1);
                    i--;
                }
                // Checks if inline comment
                else if (isComment == false && isString == false && text[i] == '/' && text[i + 1] == '/')
                {
                    int index = text.IndexOf('\n', i);
                    // Removes till newline
                    if (index != -1)
                    {
                        text = text.Remove(i, index - i); // Adds line splitter to be removed
                        i--;
                    }
                    // Removes till EOF
                    else if (index == -1)
                        text = text.Remove(i);

                }
            }

            // Outputs new text
            using (var sw = File.CreateText(fout))
                sw.WriteLine(text.Trim());

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04Sav4
{
    static class TaskUtils
    {
        private static List<string> LowerCaseList(List<string> words)
        {
            List<string> output = new List<string>();
            foreach (string word in words)
                output.Add(word.ToLower());
            return output;
        }

        public static List<string> RemoveWords(this List<string> strings, List<string> words)
        {
            List<string> lowerCaseWords = LowerCaseList(words);
            for (int i = 0; i < strings.Count; i++)
            {
                string temp = strings[i].ToLower();
                foreach (string word in lowerCaseWords)
                {
                    int index;
                    while ((index = temp.IndexOf(word)) != -1)
                    {
                        if(i != strings.Count - 1)
                            strings[i] = strings[i].Remove(index, word.Length + 1);
                        else
                            strings[i] = strings[i].Remove(index, word.Length);
                        temp = temp.Remove(index, word.Length + 1);
                    }

                }
            }

            return strings;
        }
    }
}

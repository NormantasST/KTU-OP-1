using System;
using System.Collections.Generic;
namespace Deleteme
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<char,int> dic = new Dictionary<char,int>();
            string text = Console.ReadLine();
            foreach (char c in text)
            {
               if(dic.ContainsKey(c) == false)
                    dic.Add(c, 1);
               else
                    dic[c] = dic[c] + 1;
            }

            foreach (char key in dic.Keys)
                Console.WriteLine($"{key} : {dic[key]}");

            
        }
    }
}

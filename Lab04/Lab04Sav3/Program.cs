using System;

namespace Lab04Sav3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input = "data.txt";
            Console.WriteLine($"Palindrome Count in {input}: {TaskUtils.ProcessPalindrome(input)}");
            Console.Read();
        }
    }
}

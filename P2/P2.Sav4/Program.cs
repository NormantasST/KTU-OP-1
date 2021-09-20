using System;

namespace P2.Sav4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Įveskite vardą!");
            string name = Console.ReadLine();
            Console.WriteLine($"Labas, {ConvertName(name)}!");
            Console.ReadLine();

        }

        // Converts Names to Kilmininkas
        public static string ConvertName(string name)
        {
            // Safety Net - Sutvarko gramatiką
            name = Convert.ToString(name[0]).ToUpper() + name.Substring(1, name.Length - 1).ToLower();

            if (name.EndsWith("as"))
                return name.Substring(0, name.Length - 1) + "i";

            else if (name.EndsWith("ys"))
                return name.Substring(0, name.Length - 2) + "y";

            else if (name.EndsWith("is"))
                return name.Substring(0, name.Length - 1);

            else if (name.EndsWith("a"))
                return name;

            else if (name.EndsWith("ė"))
                return name.Substring(0, name.Length - 1) + 'e';
            else
                return name;

        }
    }
}

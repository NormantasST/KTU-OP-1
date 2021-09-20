using System;

namespace P2.Sav2
{
    class Program
    {
        static void Main(string[] args)
        {
            double value;

            Console.WriteLine("Įveskite Funkcijos Kintamąjį: ");
            double x = double.Parse(Console.ReadLine());

            // Patikrina Funkcija
            if (x >= -3 && x <= 0)
                value = f1(x);
            else if (x > 0 && x <= 5)
                value = f2(x);
            else
                value = f3(x);

            Console.WriteLine($"reikšmė: \"{value}\"");
            Console.ReadLine();
        }

        // Helper funkciju deklaracija
        public static double f1 (double x) => 1 / (x - 5);
        public static double f2 (double x) => Math.Sqrt(x+5);
        public static double f3 (double x) => Math.Pow(x+3,2);
    }
}

using System;

// 1 Savarankiška Užduotis
namespace P2.Sav1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Kiek simbolių reikia išspausdinti?");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Kiek simbolių Eilutėje?");
            int width = int.Parse(Console.ReadLine());

            Console.WriteLine("Koks simbolis?");
            char character = Convert.ToChar(Console.Read());

            for (int i = 0; i < size;)
            {
                for (int y = 0; y < width && i < size; y++)
                {
                    Console.Write(character);
                    i++;
                    
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

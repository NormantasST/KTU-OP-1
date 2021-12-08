using System;
using System.Collections.Generic;

namespace Lab5Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SET UP DATA
            AnimalsContainer container = InOutUtils.ReadAnimals("Animals.csv");
            List<Animal> list = container.GetList();
            AnimalsRegister register = new AnimalsRegister(list);


            // Sav 1 InOutRewrites
            Console.WriteLine("Print Animals With Container:");
            InOutUtils.PrintAnimals("Pradiniai duomenys:", container);
            Console.WriteLine("Print Animals With Register:");
            InOutUtils.PrintAnimalsToConsole(register);
            Console.WriteLine("Print Animals With List<T>:");
            InOutUtils.PrintAnimalsToConsole(list);
            Console.WriteLine("\nPrinted Animals With List to CSV:\n");
            InOutUtils.PrintAnimalsToCSVFile("csvTest.csv", list);

            Console.WriteLine($"Aggresive dog count: {register.CountAggresiveDogs()}");

            // Sav 2 SORT
            container.Sort(new AnimalsComparatorByName());
            InOutUtils.PrintAnimals("Sorted by name:", container);
            container.Sort(new AnimalsComparatorByDate());
            InOutUtils.PrintAnimals("Sorted by Date:", container);

            // GuineaPig ADDED

            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Lab03.Register
{
    class Program
    {
        private const int index = 1;
        static void Main(string[] args)
        {

            
            // Testing Sav1
            DogsContainer dc = new DogsContainer();

            Console.WriteLine("Pradiniai testai");

            dc.Add(new Dog(1, "a", "a", DateTime.Today, Gender.Male));
            dc.Add(new Dog(2, "a", "a", DateTime.Today, Gender.Male));
            dc.Add(new Dog(3, "a", "a", DateTime.Today, Gender.Male));
            dc.Add(new Dog(4, "a", "a", DateTime.Today, Gender.Male));
            dc.Add(new Dog(5, "a", "a", DateTime.Today, Gender.Male));

            for (int i = 0; i < dc.Count; i++)
            {
                Console.WriteLine(dc.Get(i).ID);
            }

            Console.WriteLine();
            Console.WriteLine("Insert");
            
            dc.Insert(new Dog(0, "b", "a", DateTime.Today, Gender.Male),0);
            dc.Insert(new Dog(-3, "b", "a", DateTime.Today, Gender.Male), 2);
            dc.Insert(new Dog(-1, "b", "a", DateTime.Today, Gender.Male), 1);
            dc.Insert(new Dog(-100, "b", "a", DateTime.Today, Gender.Male), 100);
            for (int i = 0; i < dc.Count; i++)
            {
                Console.WriteLine(dc.Get(i).ID);
            }

            Console.WriteLine();
            Console.WriteLine("Put");

            dc.Put(new Dog(-101, "b", "a", DateTime.Today, Gender.Male), 100);
            dc.Put(new Dog(-102, "b", "a", DateTime.Today, Gender.Male), dc.Count);
            dc.Put(new Dog(-103, "b", "a", DateTime.Today, Gender.Male), 0);

            for (int i = 0; i < dc.Count; i++)
            {
                Console.WriteLine(dc.Get(i).ID);
            }

            Console.WriteLine();
            Console.WriteLine("RemoveAt");

            dc.RemoveAt(0);
            dc.RemoveAt(100);
            dc.RemoveAt(1);
            dc.RemoveAt(dc.Count - 1);
            for (int i = 0; i < dc.Count; i++)
            {
                Console.WriteLine(dc.Get(i).ID);
            }

            Console.WriteLine();
            Console.WriteLine("Remove  (All Except first)");

            for (int i = dc.Count - 1; i > 0; i--)
            {
                dc.Remove(dc.Get(i));
                Console.WriteLine($"Removed {i}");
            }

            Console.WriteLine($"First Element (0) Value is: {dc.Get(0)}");
            Console.WriteLine($"Count: {dc.Count}");


            
            DogsContainer allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            InOutUtils.PrintDogs("ner:", allDogs);
            allDogs.Sort();

            DogsContainer newDogs = new DogsContainer(allDogs);

            InOutUtils.PrintDogs("Rikiutoi:", allDogs);

            InOutUtils.PrintDogs("Copy", newDogs);
            
            Console.Read();

        }
    }
}

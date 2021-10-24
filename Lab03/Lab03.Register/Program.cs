using System;
using System.Collections.Generic;

namespace Lab03.Register
{
    class Program
    {
        private const int index = 1;
        static void Main(string[] args)
        {
            DogsContainer dc = new DogsContainer();

            dc.Add(new Dog(1,"a","a",DateTime.Today, Gender.Male));
            Console.WriteLine(dc.Get(0).ID);
            dc.Insert(new Dog(2, "b", "a", DateTime.Today, Gender.Male),1);
            Console.WriteLine(dc.Get(0).ID);
            dc.Put(new Dog(3, "c", "a", DateTime.Today, Gender.Male), 0);
            Console.WriteLine(dc.Get(0).ID);
            Console.WriteLine(dc.Get(1).ID);

            dc.RemoveAt(0);
            Console.WriteLine(dc.Count);
            Console.WriteLine(dc.Get(0).ID);
            Console.WriteLine(dc.Count);

            //dc.Remove();

            Console.Read();

        }
    }
}

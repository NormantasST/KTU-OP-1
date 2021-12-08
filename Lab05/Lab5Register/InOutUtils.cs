using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5Register
{
    static class InOutUtils
    {
        private const int fSize = -20;
        /// <summary>
        /// Prints Dogs to Console
        /// </summary>

        public static string InfoString(string splitter)
        {
            return $"{"Gyvūno tipas", fSize}{splitter}{"Reg.Nr.",fSize}{splitter}{"Vardas",fSize}{splitter}{"Veislė",fSize}{splitter}{"Gimimo data",fSize * 3 / 2}{splitter}{"Lytis",fSize}{splitter}{"Agresyvumas", fSize}";
        }

        public static void PrintAnimalsToConsole(List<Animal> animals)
        {
            Console.WriteLine(new string('-', 150));
            Console.WriteLine(InfoString("|"));

            Console.WriteLine(new string('-', 150));

            string splitter = "|";
            if(animals.Count > 0)
                foreach(Animal animal in animals)
                {
                    Console.WriteLine(animal);
                }
            else
                Console.WriteLine("No Data Found");
            Console.WriteLine(new string('-', 150));

        }

        public static void PrintAnimalsToConsole(AnimalsRegister animals)
        {
            const string splitter = "|";
            Console.WriteLine(InfoString(splitter));
            if(animals != null)
                for (int i = 0; i < animals.Count; i++)
                {
                    Animal animal = animals.Get(i);
                    Console.WriteLine(animal);
                }
            else
                Console.WriteLine("No Data Found");
        }

        public static void PrintAnimalsToCSVFile(string fileName, List<Animal> animals)
        {
            const string splitter = ";";
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
            {
                sw.WriteLine(InfoString(splitter));
                if (animals.Count > 0)
                    foreach (Animal animal in animals)
                    {
                        sw.WriteLine(animal.ToString(splitter));
                    }
                else
                    sw.WriteLine("No Data Found");
            }
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintAnimals(string label, AnimalsContainer animals)
        {
             Console.WriteLine(new string('-', 150));
             Console.WriteLine("| {0,-70} |", label);
             Console.WriteLine(new string('-', 150));
             Console.WriteLine(InfoString("|"));

             Console.WriteLine(new string('-', 150));

            if(animals.Count > 0)
                 for (int i = 0; i < animals.Count; i++)
                 {
                    Animal animal = animals.Get(i);
                    Console.WriteLine(animal);
                 }
             else
                Console.WriteLine("No Data Found");

            Console.WriteLine(new string('-', 150));
        }

        public static AnimalsContainer ReadAnimals(string fileName)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string type = values[0].ToUpper();
                int id = int.Parse(values[1]);
                string name = values[2];
                string breed = values[3];
                DateTime birthDate = DateTime.Parse(values[4]);
                Gender gender;
                Enum.TryParse(values[5], out gender); //tries to convert value to enum
                switch (type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "GUINEAPIG":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(guineaPig);
                        break;
                    default:
                        break;//unknown type
                }
            }
            return animals;
        }

        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab03.Register
{
    static class InOutUtils
    {
        private const int fSize = -20;
        /// <summary>
        /// Prints Dogs to Console
        /// </summary>
        public static void PrintDogs(List<Dog> Dogs)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |",
           "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            foreach (Dog dog in Dogs)
            {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
               dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }
        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static DogsRegister ReadDogs(string fileName)
        {
            DogsRegister Dogs = new DogsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);
                Gender gender;
                Enum.TryParse(Values[4], out gender); //tries to convert value to enum
                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            }
            return Dogs;
        }

        public static void PrintDogsToCSVFile(string fileName, List<Dog> Dogs)
        {
            string[] lines = new string[Dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}",
            "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}",
                Dogs[i].ID, Dogs[i].Name, Dogs[i].Breed, Dogs[i].BirthDate, Dogs[i].Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints dogs to Console
        /// </summary>
        public static void PrintDogsToConsole(DogsRegister dogs)
        {
            Console.WriteLine(new string('-', 115));
            Console.WriteLine($"{"Reg.Nr.",fSize}|{"Vardas",fSize}|{"Veislė",fSize}|{"Gimimo data",fSize * 3 / 2}|{"Lytis",fSize}|");
            Console.WriteLine(new string('-', 115));
            for (int i = 1; i <= dogs.DogsCount(); i++)
            {
                Dog dog = dogs.FindByIndex(i);
                Console.WriteLine($"{dog.ID,-fSize}|{dog.Name,fSize}|{dog.Breed,fSize}|{dog.BirthDate,fSize*3/2}|{dog.Gender,fSize}|");
            }
        }

        public static void PrintDogsToConsole(List<Dog> dogs)
        {
            Console.WriteLine(new string('-', 115));
            Console.WriteLine($"{"Reg.Nr.",fSize}|{"Vardas",fSize}|{"Veislė",fSize}|{"Gimimo data",fSize * 3 / 2}|{"Lytis",fSize}|");
            Console.WriteLine(new string('-', 115));
            foreach (Dog dog in dogs)
                Console.WriteLine($"{dog.ID,-fSize}|{dog.Name,fSize}|{dog.Breed,fSize}|{dog.BirthDate,fSize * 3 / 2}|{dog.Gender,fSize}|");

            
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

using System;
using System.Collections.Generic;

namespace Lab02.Register
{
    class Program
    {
        private const int index = 1;
        static void Main(string[] args)
        {
            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine($"Index: {index} Dog's Name Is: {register.FindByIndex(index).Name}");
            InOutUtils.PrintDogsToConsole(register);

            Console.WriteLine("Filtered Dogs By Vaccination");
            List<Vaccination> vaccinations = InOutUtils.ReadVaccinations("Vaccinations.csv");
            register.UpdateVaccinationsInfo(vaccinations);
            InOutUtils.PrintDogsToConsole(register.FilterByVaccinationExpired());

            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));

            Console.Read();

            /*
            List<Dog> allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(allDogs);
            Console.WriteLine("Iš viso šunų: {0}", allDogs.Count);

            Console.WriteLine("Patinų: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
            Console.WriteLine("Patelių: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
            Console.WriteLine();

            Dog oldest = TaskUtils.FindOldestDog(allDogs);
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
             oldest.Name, oldest.Breed, oldest.CalculateAge());

            List<string> Breeds = TaskUtils.FindBreeds(allDogs);
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();

            List<Dog> filteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            InOutUtils.PrintDogs(filteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, filteredByBreed);
            */
        }
    }
}

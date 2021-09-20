using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.Register
{
    static class TaskUtils
    {

        public static List<string> FindBreeds(List<Dog> Dogs)
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in Dogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public static List<Dog> FilterByBreed(List<Dog> Dogs, string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

    }
}

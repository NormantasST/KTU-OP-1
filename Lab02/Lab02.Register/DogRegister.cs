using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.Register
{
    class DogsRegister
    {
        private List<Dog> AllDogs;
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }

        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }
        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }

        /// <summary>
        /// Finds Dog By Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Dog</returns>
        public Dog FindByIndex(int index)
        {
            Dog output;

            try
            {
                output = AllDogs[index];
            }
            catch (Exception)
            {
                output = null;
            }

            return output;
        }

        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }
        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++) //starts on index value 1
            {
                if (DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }

        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }

        /// <summary>
        /// Filters for Unvaccinated Dogs
        /// </summary>
        /// <returns>List Dog Object</returns>
        public List<Dog> FilterByVaccinationExpired()
        {
            List<Dog> filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
                if (dog.RequiresVaccination)
                    filtered.Add(dog);
            
            return filtered;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (vaccination > dog.LastVaccinationDate)
                {
                    dog.LastVaccinationDate = vaccination.Date;
                }
            }
        }


    }
}

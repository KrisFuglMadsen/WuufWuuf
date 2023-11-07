using KennelCarolinekilde.Models;
using KennelCarolinekilde.Models.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.ViewModels
{
    public class DogVM: ViewModelBase
    {
        DogRepo dogRepo = new DogRepo();
        public List<Dog> GetDogsByCriteria(string ad, string hd, string hz, string sp, string color, string age, string sex)
        {
            List<Dog> dogs = dogRepo.GetListOfDogs(ad, hd, hz, sp, color, age, sex);
            return dogs;
        }
        public string CreateDog(string pedigreeNr, string sex)
        {
            return null;
        }
        public string CreateDog(string pedigreeNr, string name, string sex)
        {
            return null;
        }
        public string CreateDog(string pedigreeNr, string name, string father, string mother, string sex)
        {
            return null;
        }
        public string CreateDog(string pedigreeNr, string name, string father, string mother, DateOnly dateOfBirth, string sex)
        {
            return null;
        }
        public string CreateDog(string pedigreeNr, string name, string father, string mother, DateOnly dateOfBirth, string sex, string hdIndex)
        {
            return null;
        }
        public string CreateDog(string pedigreeNr, string name, string father, string mother, DateOnly dateOfBirth, string sex, string hdIndex, string color)
        {
            return null;
        }
        public string CreateDog(string pedigreeNr, string name, string father, string mother, DateOnly dateOfBirth, string sex, string hdIndex, string color, bool dead)
        {
            return null;
        }
        public string CreateDog(string pedigreeNr, string name, string father, string mother, DateOnly dateOfBirth, string sex, string hdIndex, string color, bool dead, bool breedStatus)
        {
            return null;
        }
        //TODO finish the overloading. Owner image and medical is missing 
    }
}

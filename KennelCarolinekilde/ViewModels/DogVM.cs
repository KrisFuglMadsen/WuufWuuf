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

        //--------------Create dog with two requirements (pedigreeNr and name)-------------------------------------------
        public string CreateDog(string pedigreeNr, string name, string father = null, string mother = null, DateOnly dateOfBirth = default(DateOnly), 
            string sex = null, string hdIndex = null, string color = null, bool dead = false, bool breedStatus = false, string image = null, string ownerId = null, 
            string hd = null, string ad = null, string hz = null, string sp = null)
        {
            return dogRepo.CreateDog(pedigreeNr, name, father, mother, dateOfBirth, sex, hdIndex, color, dead, breedStatus, image, ownerId, hd, ad, hz, sp);
        }
        //TODO finish the overloading. Owner image and medical is missing 

        public Dog GetSingleDog(string search)
        {
            DogRepo dogRepo = new DogRepo();
            Dog dog = dogRepo.GetSingleDog(search);
            return dog;
        }
    }
}

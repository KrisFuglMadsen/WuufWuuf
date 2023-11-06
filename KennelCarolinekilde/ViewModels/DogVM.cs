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


    }
}

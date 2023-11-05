using KennelCarolinekilde.Models;
using KennelCarolinekilde.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KennelCarolinekilde.ViewModels
{
    public class BreedingVM : ViewModelBase
    {
        public Dog GetSingleDog(string search)
        {
            DogRepo dogRepo = new DogRepo();
            Dog dog = dogRepo.GetSingleDog(search);
            return dog;
        }
    }
}

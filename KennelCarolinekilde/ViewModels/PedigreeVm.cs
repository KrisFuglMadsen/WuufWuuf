using KennelCarolinekilde.Models;
using KennelCarolinekilde.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.ViewModels
{
    public class PedigreeVm: ViewModelBase

    {

        public PedigreeVm() { }

        public List<List<Dog>> GetFamilyTree(string pedigreeNr)
        {
            DogRepo dogRepo = new DogRepo();
            return dogRepo.GetFamilyTree(pedigreeNr);
        }
    }
}

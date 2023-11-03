using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models.Repos
{
    public class DogRepo: RepoBase
    {
        public List<Dog> dogList { get; private set; } = new List<Dog>();

        //--------------------Constructor--------------------------------
        public DogRepo() { }

        //--------------------Methods------------------------------------

        //TODO write the logic for GetSingleDog
        public Dog GetSingleDog(string name, string pedigreeNr) { return null; }

        //TODO write the logic for GetListOfDogs for all overloads
        public List<Dog> GetListOfDogs(string name, string pedigreeNr) { return null; }
        public List<Dog> GetListOfDogs(List<string> health, List<string> color, int age) { return null; }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models
{
    public class Dog
    {
        //----------------Fields-------------------------------------
        public string Name { get; private set; }
        public string PedigreeNr { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Father { get; private set; }
        public string  Mother { get; private set; }
        public decimal HDIndex { get; private set; }
        public char Sex { get; private set; }
        public string Color { get; private set; }
        public bool Alive { get; private set; }
        public bool BreedStatus { get; private set; }
        public Owner Owner { get; private set; }
        public string Image { get; private set; }
        public List<Title> Titles { get; private set; }
        public List<DKK_Title> MyProperty { get; private set; }
        
        //---------------------Constructor-----------------------

        public Dog() { }

        //------------------------Methods-------------------------
       
        //TODO write the logic to UpdateDog
        public void UpdateDog()
        { }

        //TODO write the logic to UpdatTitles
        public void UpdateTiltes()
        {

        }

        //TODO write the logic to UpdateDKKTiltles
        public void UpdateDKK_Titles()
        {

        }

        //TODO write the logic for AddTitle
        public void AddTitle()
        {

        }

        //TODO write the logic to AddDKK_Titles
        public void AddDKK_Titles()
        {

        }

        //TODO write the logic to DeleteTitle
        public void DeleteTitle() { }

        //TODO write the logic to DeleteDKK_Titles
        public void DeleteDKK_Titles() { }

        public override string ToString()
        {
            return $"{this.Name}, {this.PedigreeNr}";
        }
    }
}

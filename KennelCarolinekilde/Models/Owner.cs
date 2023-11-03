using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set;}
        public string Adresse { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public Owner() { }

        //----------------Methods-------------------------

        //TODO write the logic to Update
        public void Update() { }

        public override string ToString()
        {
            return $"{this.FirstName} {LastName} ";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models.Repos
{
    public class OwnerRepo: RepoBase
    {
        public List<Owner> Owners { get; set; } = new List<Owner>();

    }


    //TODO write the logic for for CRUD (inheritance)

}

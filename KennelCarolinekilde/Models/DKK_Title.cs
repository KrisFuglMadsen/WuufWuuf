using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models
{
    public class DKK_Title : TitleBase
    {
        public DKK_Title() { }
        // TODO lav logik for Update   
        public override void Update() { }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}

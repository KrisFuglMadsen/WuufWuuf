using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models
{
    public class Title : TitleBase
    {
        public override void Update() { }

        public override string ToString()
        {
            return $"{this.Name}";
        }

        //TODO write the logic to Update

    }

}

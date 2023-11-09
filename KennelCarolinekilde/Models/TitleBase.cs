using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models
{
    public abstract class TitleBase
    {
        public string Name { get; private set; }
        public virtual void Update() { }
        
    }
}

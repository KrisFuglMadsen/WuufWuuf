using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelCarolinekilde.Models.Repos
{
    public abstract class RepoBase
    {
        public virtual void Create() { }
        public virtual void Update() { }
        public virtual void Delete() { } 
        public virtual void Get() { }

    }
}

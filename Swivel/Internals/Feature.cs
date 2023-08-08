using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swivel.Internals
{
    public abstract class Feature
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public abstract void Setup();

        public virtual void Update()
        {

        }

        public abstract void CleanUp();

        public bool IsLoaded { get; set; } = false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraries
{
    /**
     * Generic purpose name/value pair
     * Known usage: Combo Box Dropdown
     */
    public class ProjectItem
    {
        public string Name;
        public string Value;

        public override string ToString()
        {
            return this.Value;
        }
    }
}

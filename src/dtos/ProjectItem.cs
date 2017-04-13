using System;

namespace dtos
{
    /**
     * Generic purpose name/value pair
     * Known usage: Combo Box Dropdown
     */
    public class ProjectItem
    {
        public Guid ProjectID;
        public string Name;
        public string Value;

        public override string ToString()
        {
            return this.Value;
        }
    }
}

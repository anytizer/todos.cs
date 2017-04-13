using System;

namespace dtos
{
    /**
     * Generic purpose name/value pair
     * Known usage: Combo Box Dropdown
     */
    public class NameValueDTO
    {
        public Guid id;
        public string name;
        public string value;

        public override string ToString()
        {
            return this.value;
        }
    }
}

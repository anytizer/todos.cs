using System;

namespace dtos
{
    /**
     * Generic purpose name/value pair
     * Known usage: Combo Box Dropdown
     */
    public class NameValueDTO
    {
        public Guid id { get; set;  }
        public string name { get; set; }
        public string value { get; set; }

        /**
         * Ask some questions before performing any action
         */
        public bool confirm { get; set; }
        public string question { get; set; }

        public override string ToString()
        {
            return this.value;
        }
    }
}

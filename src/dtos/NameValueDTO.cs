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

        /**
         * Ask some questions before performing any action
         */
        public bool confirm;
        public string question;

        public override string ToString()
        {
            return this.value;
        }
    }
}

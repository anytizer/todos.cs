using System;

namespace database
{
    public class statuses
    {
        /**
         * Status repository
         */
        public Guid delete_status()
        {
            return dtos.defaults.statuses.DELETED;
        }
    }
}

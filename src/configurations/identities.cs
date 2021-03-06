﻿using settingsmanager;
using System;
using static settingsmanager.ids;

namespace configurations
{
    /**
     * Repository of IDs
     */
    public class identities
    {
        public Guid ProjectID_default
        {
            get
            {
                /**
                 * @todo Project: configurations.identities (separate project)
                 * @see identity.dll
                 */
                ids i = new ids();
                return i.ProjectID;
            }
            private set { }
        }

        /**
         * Default User ID to login internally
         */
        public Guid UserID_default
        {
            get
            {
                /**
                 * @todo Project: configurations.identities (separate project)
                 * @see identity.dll
                 */
                ids i = new ids();
                return i.UserID;
            }
            private set { }
        }

        /**
         * GUID of a todo status just created
         */
        public Guid status_new
        {
            get
            {
                StatusIDs st = new StatusIDs();
                return st.NEW;
            }
            private set { }
        }
    }
}


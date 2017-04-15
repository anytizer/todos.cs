using settingsmanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configurations
{
    public class identities
    {
        public Guid ProjectID
        {
            get
            {
                /**
                 * @todo Project: configurations.identities (separate project)
                 * @see identity.dll
                 */
                identities i = new identities();
                return i.ProjectID;
            }
            private set { }
        }

        public Guid UserID
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

        public StatusIDs status()
        {
            StatusIDs st = new StatusIDs();
            return st;
        }
    }
}

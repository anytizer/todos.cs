using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace settingsmanager
{
    public class ids
    {
        /**
         * Generated for: todos.
         * Compile and link to this DLL only.
         * Do not add application source code to your project.
         */
        public readonly Guid ApplicationID = new Guid("1FDE062B-4659-4680-832E-03794626A613");

        /**
         * Who should register
         */
        public readonly Guid UserID = new Guid("C50EF177-16A1-4B0C-A8EA-5F985355E7A1");

        /**
         * The default project
         */
        public readonly Guid ProjectID = new Guid("6F39DA75-EE09-44EA-80DB-23087F0C555D");

        public class StatusIDs
        {
            // SELECT CONCAT('public static Guid ', status_code, '= new Guid("', status_id, '");') FROM todo_statuses ORDER BY status_priority;
            public readonly Guid NEW = new Guid("E827C910-5235-4C87-9F13-DAF960682D51");
            public readonly Guid DOING = new Guid("E827C910-5235-4C87-9F13-DAF960682D52");
            public readonly Guid LOWPRIORITY = new Guid("E827C910-5235-4C87-9F13-DAF960682D53");
            public readonly Guid DONE = new Guid("E827C910-5235-4C87-9F13-DAF960682D54");
            public readonly Guid NOTNEEDED = new Guid("E827C910-5235-4C87-9F13-DAF960682D55");
            public readonly Guid CANNOTBEDONE = new Guid("E827C910-5235-4C87-9F13-DAF960682D56");
            public readonly Guid DELETED = new Guid("E827C910-5235-4C87-9F13-DAF960682D57");
        }
    }
}

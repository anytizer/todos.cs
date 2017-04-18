using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace settingsmanager
{
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

        //  // = new Guid("E827C910-5235-4C87-9F13-DAF960682D51"); // New
    }
}

using System;

namespace configurations.defaults
{
    public class statuses
    {
        // SELECT CONCAT('public static Guid ', status_code, '= new Guid("', status_id, '");') FROM todo_statuses ORDER BY status_priority;
        public static readonly Guid NEW = new Guid("E827C910-5235-4C87-9F13-DAF960682D51");
        public static readonly Guid DOING = new Guid("E827C910-5235-4C87-9F13-DAF960682D52");
        public static readonly Guid LOWPRIORITY = new Guid("E827C910-5235-4C87-9F13-DAF960682D53");
        public static readonly Guid DONE = new Guid("E827C910-5235-4C87-9F13-DAF960682D54");
        public static readonly Guid NOTNEEDED = new Guid("E827C910-5235-4C87-9F13-DAF960682D55");
        public static readonly Guid CANNOTBEDONE = new Guid("E827C910-5235-4C87-9F13-DAF960682D56");
        public static readonly Guid DELETED = new Guid("E827C910-5235-4C87-9F13-DAF960682D57");
    }
}

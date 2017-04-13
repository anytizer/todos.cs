using System;

namespace dtos.defaults
{
    public class statuses
    {
        // SELECT CONCAT('public static Guid ', status_code, '= new Guid("', status_id, '");') FROM todo_statuses ORDER BY status_code;
        public static Guid CANNOTBEDONE = new Guid("E827C910-5235-4C87-9F13-DAF960682D58");
        public static Guid DELETED = new Guid("E827C910-5235-4C87-9F13-DAF960682D59");
        public static Guid DOING = new Guid("E827C910-5235-4C87-9F13-DAF960682D55");
        public static Guid DONE = new Guid("E827C910-5235-4C87-9F13-DAF960682D56");
        public static Guid LOWPRIORITY = new Guid("E827C910-5235-4C87-9F13-DAF960682D53");
        public static Guid NEW = new Guid("E827C910-5235-4C87-9F13-DAF960682D54");
        public static Guid NOTNEEDED = new Guid("E827C910-5235-4C87-9F13-DAF960682D57");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtos
{
    public class defaults
    {
        public static Guid ProjectID = new Guid("640BC432-CDFF-4B7D-8D04-C418CD989AA3");
        public static Guid StatusID = new Guid("E827C910-5235-4C87-9F13-DAF960682D54");
    }

    public class statuses
    {
        public static Guid DONE = new Guid("E827C910-5235-4C87-9F13-DAF960682D56");
        public static Guid LOWPRIORITY = new Guid("2D74F370-A8CC-44F7-9920-309D879EA431");
    }
}

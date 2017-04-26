using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public static class ConnectionStrings
    {
        public static string plain()
        {
            //return "server=localhost;user id=awesome;password=awesome;persistsecurityinfo=True;database=awesome_todos;port=4040";
            return "Server=localhost;Uid=awesome;Pwd=awesome;Database=awesome_todos;persistsecurityinfo=True";
            // Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd = myPassword;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpers
{
    public static class ConnectionStringHelper
    {
        public static string cs()
        {
            string connection_string = "";
            ConnectionString cs = new ConnectionString();

            //connection_string = cs.odbc();
            //connection_string = cs.native();
            //connection_string = cs.dsn();
            connection_string = cs.edmx();
            //System.Windows.Forms.MessageBox.Show(connection_string);

            return connection_string;
        }
    }

   
}

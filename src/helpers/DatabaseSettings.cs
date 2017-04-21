using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpers
{
    internal class DatabaseSettings
    {
        public string DRIVER { get; private set; }
        public string HOSTNAME { get; private set; }
        public string PORTNUMBER { get; private set; }
        public string DATABASE { get; private set; }
        public string USERNAME { get; private set; }
        public string PASSWORD { get; private set; }

        public DatabaseSettings()
        {
            int mode = 0; // 0: direct, 1: proxy
            switch (mode)
            {
                case 0:
                    // Shared on LAN
                    DRIVER = "MySQL";
                    HOSTNAME = "localhost";
                    PORTNUMBER = "3306"; // Direct connection
                    USERNAME = "awesome";
                    PASSWORD = "awesome";
                    DATABASE = "awesome_todos";
                    break;
                case 1:
                default:
                    // Traced with Proxy Server
                    DRIVER = "MySQL";
                    HOSTNAME = "localhost";
                    PORTNUMBER = "4040"; // Neor Profile SQL
                    USERNAME = "awesome";
                    PASSWORD = "awesome";
                    DATABASE = "awesome_todos";
                    break;
            }
        }
    }
}

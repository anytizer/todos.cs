using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpers
{
    /**
     * @see http://stackoverflow.com/questions/6567037/keyword-not-supported-exception-when-attempting-to-use-a-connection-string-that-p
     * @see https://blogs.msdn.microsoft.com/rickandy/2008/12/09/explicit-connection-string-for-ef/
     */
    public class ConnectionString
    {
        DatabaseSettings settings;

        public ConnectionString()
        {
            settings = new DatabaseSettings();
        }

        public string dsn()
        {
            string dsn_string = "dsn";
            string ConnectionString = string.Format("DSN={0}.mysql;SERVER={1};DATABASE={2};UID={3};PASSWORD={4};OPTION=3", dsn_string, settings.HOSTNAME, settings.PORTNUMBER, settings.DATABASE, settings.USERNAME, settings.PASSWORD);
            return ConnectionString;
        }

        public string edmx()
        {
            /**
             * @todo Seems, password may have been skipped.
             * The DOUBLE QUOTATION MARKS are in use
             */
            string ConnectionString = string.Format(@"metadata=res://*/Inventories.InventoriesModels.csdl|res://*/Inventories.InventoriesModels.ssdl|res://*/Inventories.InventoriesModels.msl;provider=MySql.Data.MySqlClient;provider connection string=""server={0};port={1};user id={3};password={4};database={2};persistsecurityinfo=True;"";", settings.HOSTNAME, settings.PORTNUMBER, settings.DATABASE, settings.USERNAME, settings.PASSWORD);
            return ConnectionString;
        }

        public string native()
        {
            string ConnectionString = string.Format("SERVER={0};PORT={1};DATABASE={2};UID={3};PASSWORD={4};CHARSET=utf8;", settings.HOSTNAME, settings.PORTNUMBER, settings.DATABASE, settings.USERNAME, settings.PASSWORD);
            return ConnectionString;
        }

        public string odbc()
        {
            /**
             * @see https://www.connectionstrings.com/mysql/
             * @see https://dev.mysql.com/doc/connector-odbc/en/connector-odbc-configuration-connection-without-dsn.html
             * @file mysql-connector-odbc-5.3.6-winx64.msi
             * @see http://stackoverflow.com/questions/6567037/keyword-not-supported-exception-when-attempting-to-use-a-connection-string-that
             */
            string driver = "{MySQL ODBC 5.3 Unicode Driver}";
            string ConnectionString = string.Format(@"DRIVER={0};Server={1};Port={2};Database={3};Uid={4};Password={5};", driver, settings.HOSTNAME, settings.PORTNUMBER, settings.DATABASE, settings.USERNAME, settings.PASSWORD);
            return ConnectionString;
        }

        /**
         * Auto determine which mode the use?
         */
        public override string ToString()
        {
            return this.native();
        }
    }
}

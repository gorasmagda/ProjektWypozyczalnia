using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL
{
    class DBConnectionUser : IDBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        private static DBConnectionUser instance = null;
        public static DBConnectionUser Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnectionUser();
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnectionUser()
        {
            stringBuilder.UserID = Properties.Settings.Default.pracownikID;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.pracownikPaswd;
            stringBuilder.SslMode = MySqlSslMode.Required;
        }

        public MySqlConnection GetConnection()
        {
            return Connection;
        }
    }
}

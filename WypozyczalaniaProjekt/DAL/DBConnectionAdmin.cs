using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL
{
    class DBConnectionAdmin : IDBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        private static DBConnectionAdmin instance = null;
        public static DBConnectionAdmin Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnectionAdmin();
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnectionAdmin()
        {
            //stworzenie connection stringa na podstawie danych zapisanych w Sttings do których mamy dostęp spoza aplikacji 
            stringBuilder.UserID = Properties.Settings.Default.wlascicielID;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.wlascicielPaswd;
            stringBuilder.SslMode = MySqlSslMode.Required;
        }

        public MySqlConnection GetConnection()
        {
            return Connection;
        }
    }
}

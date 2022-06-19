using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL
{
    interface IDBConnection
    {
        MySqlConnection GetConnection();
    }
}

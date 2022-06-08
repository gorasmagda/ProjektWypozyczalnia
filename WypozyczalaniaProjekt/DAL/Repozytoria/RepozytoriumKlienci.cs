using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;

    class RepozytoriumKlienci
    {
        #region ZAPYTANIA
        private const string WSZYSCY_KLIENCI = "SELECT * FROM klienci";
        #endregion

        #region metody CRUD
        public static List<Klient> PobierzWszystkichKlientow()
        {
            List<Klient> klienci = new List<Klient>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_KLIENCI, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    klienci.Add(new Klient(reader));
                connection.Close();

            }
            return klienci;
        }
        #endregion
    }
}

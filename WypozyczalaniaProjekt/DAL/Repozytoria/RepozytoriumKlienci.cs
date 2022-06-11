using System.Collections.Generic;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;

    class RepozytoriumKlienci
    {

        #region ZAPYTANIA
        private const string WSZYSCY_KLIENCI = "SELECT * FROM klienci";
        private const string DODAJ_KLIENTA = "INSERT INTO klienci VALUES ";
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

        public static bool DodajKlientaDoBazy(Klient klient)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_KLIENTA} {klient.ToInsert()}", connection);
                connection.Open();
                var reader = command.ExecuteNonQuery();
                stan = true;
                klient.IdKlient = (sbyte)command.LastInsertedId;
                connection.Close();
            }

            return stan;
        }

        #endregion
    }
}

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

        public static bool EdytujKlientaWBazie(Klient k, sbyte idKlient)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_KLIENTA = $"UPDATE klienci SET imie='{k.Imie}', nazwisko='{k.Nazwisko}', plec='{k.Plec}', email='{k.Email}', " +
                    $"nr_telefonu='{k.NrTelefonu}', adres='{k.Adres}', pesel='{k.Pesel}', nr_prawa_jazdy='{k.NrPrawaJazdy}', " +
                    $"data_urodzenia='{k.DataUrodzenia:yyyy-MM-dd}', id_karta='{k.IdKarty}' WHERE id_klient='{idKlient}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_KLIENTA, connection);
                connection.Open();
                var edit = command.ExecuteNonQuery();
                if (edit == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        #endregion
    }
}

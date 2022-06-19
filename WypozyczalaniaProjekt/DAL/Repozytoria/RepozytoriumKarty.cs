using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WypozyczalaniaProjekt.DAL.Encje;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    class RepozytoriumKarty
    {
        #region ZAPYTANIA

        private const string WSZYSTKIE_KARTY = "SELECT * FROM karty_kredytowe";
        private const string DODAJ_KARTE = "INSERT INTO karty_kredytowe VALUES ";

        #endregion

        #region metody CRUD

        public static List<KartaKredytowa> PobierzWszystkieKarty(IDBConnection database)
        {
            List<KartaKredytowa> karty = new List<KartaKredytowa>();

            using (var connection = database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_KARTY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    karty.Add(new KartaKredytowa(reader));
                connection.Close();

            }
            return karty;
        }

        public static bool DodajKarteDoBazy(IDBConnection database, KartaKredytowa karta)
        {
            bool stan = false;
            using (var connection = database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_KARTE} {karta.ToInsert()}", connection);
                connection.Open();
                var reader = command.ExecuteNonQuery();
                stan = true;
                karta.IdKarty = (sbyte)command.LastInsertedId;
                connection.Close();
            }

            return stan;
        }

        public static bool EdytujKarteWBazie(IDBConnection database, KartaKredytowa kk, sbyte idKarta, Klient k)
        {
            bool stan = false;
            using (var connection = database.GetConnection())
            {
                string EDYTUJ_KARTE = $"UPDATE karty_kredytowe SET numer='{kk.Numer}', data_waznosci='{kk.DataWaznosci:yyyy-MM-dd}', numer_CVV='{kk.NumerCVV}', imie='{k.Imie}', nazwisko='{k.Nazwisko}', rodzaj='{kk.Rodzaj}' WHERE id_karta='{idKarta}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_KARTE, connection);
                connection.Open();
                var edit = command.ExecuteNonQuery();
                if (edit == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool UsunKarteZBazy(IDBConnection database, sbyte idKarta)
        {
            bool stan = false;
            using (var connection = database.GetConnection())
            {
                string USUN_KARTE = $"DELETE FROM karty_kredytowe WHERE id_karta='{idKarta}'";

                MySqlCommand command = new MySqlCommand(USUN_KARTE, connection);
                connection.Open();
                var delete = command.ExecuteNonQuery();
                if (delete == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        #endregion
    }
}

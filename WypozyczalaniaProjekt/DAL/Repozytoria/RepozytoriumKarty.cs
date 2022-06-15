using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static List<KartaKredytowa> PobierzWszystkieKarty()
        {
            List<KartaKredytowa> karty = new List<KartaKredytowa>();

            using (var connection = DBConnection.Instance.Connection)
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

        public static bool DodajKarteDoBazy(KartaKredytowa karta)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
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

        public static bool EdytujKarteWBazie(KartaKredytowa kk, sbyte idKarta)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_KARTE = $"UPDATE karty_kredytowe SET numer='{kk.Numer}', data_waznosci='{kk.DataWaznosci}', numer_CVV='{kk.NumerCVV}', imie='{kk.Imie}', nazwisko='{kk.Nazwisko}', rodzaj='{kk.Rodzaj}' WHERE id_karta='{idKarta}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_KARTE, connection);
                connection.Open();
                var edit = command.ExecuteNonQuery();
                if (edit == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool UsunKarteZBazy(sbyte idKarta)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
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

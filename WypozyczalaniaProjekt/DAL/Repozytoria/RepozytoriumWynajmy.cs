using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalaniaProjekt.DAL.Encje;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    class RepozytoriumWynajmy
    {
        #region ZAPYTANIA

        private const string WSZYSTKIE_WYNAJMY = "SELECT * FROM wynajem";
        private const string DODAJ_WYNAJEM = "INSERT INTO wynajem VALUES ";

        #endregion

        #region metody CRUD

        public static List<Wynajem> PobierzWszystkieWynajmy()
        {
            List<Wynajem> wynajmy = new List<Wynajem>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_WYNAJMY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    wynajmy.Add(new Wynajem(reader));
                connection.Close();

            }
            return wynajmy;
        }

        public static bool DodajWynajemDoBazy(Wynajem wynajem)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_WYNAJEM} {wynajem.ToInsert()}", connection);
                connection.Open();
                var reader = command.ExecuteNonQuery();
                stan = true;
                wynajem.IdWynajem = (sbyte)command.LastInsertedId;
                connection.Close();
            }

            return stan;
        }

        public static bool EdytujWynajemWBazie(Wynajem w, sbyte idWynajem)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_WYNAJEM = $"UPDATE wynajem SET data_wypozyczenia='{w.DataWypozyczenia:yyyy-MM-dd}', data_zwrotu='{w.DataZwrotu:yyyy-MM-dd}', calkowity_koszt='{w.CalkowityKoszt}', id_auto='{w.IdAuto}', id_klient='{w.IdKlient}', id_pracownik='{w.IdPracownik}' WHERE id_wynajem='{idWynajem}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_WYNAJEM, connection);
                connection.Open();
                var edit = command.ExecuteNonQuery();
                if (edit == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool UsunWynajemZBazy(sbyte idWynajem)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_WYNAJEM = $"DELETE FROM wynajem WHERE id_wynajem='{idWynajem}'";

                MySqlCommand command = new MySqlCommand(USUN_WYNAJEM, connection);
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

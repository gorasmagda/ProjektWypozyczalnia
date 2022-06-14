using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;
    class RepozytoriumOddzialy
    {
        #region ZAPYTANIA

        private const string WSZYSTKIE_ODDZIALY = "SELECT * FROM oddzialy order by id_oddzialu asc";
        private const string DODAJ_ODDZIAL = "INSERT INTO oddzialy (adres, nr_telefonu, nazwa) VALUES";
        
        #endregion

        #region metody CRUD

        public static List<Oddzial> PobierzWszystkieOddzialy()
        {
            List<Oddzial> oddzialy = new List<Oddzial>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_ODDZIALY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    oddzialy.Add(new Oddzial(reader));
                connection.Close();
            }
            return oddzialy;
        }

        public static bool DodajOddzialDoBazy(Oddzial oddzial)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ODDZIAL} {oddzial.ToInsert()}", connection);
                connection.Open();
                var add = command.ExecuteNonQuery();
                stan = true;
                oddzial.IdOddzialu = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujOddzialWBazie(Oddzial od, sbyte idOddzialu)
        {
            bool stan = false;
            using (var connenction = DBConnection.Instance.Connection)
            {
                string EDYTUJ_ODDZIAL = $"UPDATE oddzialy SET adres='{od.Adres}',nr_telefonu='{od.NrTelefonu}', nazwa='{od.Nazwa}' WHERE id_oddzialu='{idOddzialu}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_ODDZIAL, connenction);
                connenction.Open();
                var edit = command.ExecuteNonQuery();
                if (edit == 1) stan = true;
                connenction.Close();
            }
            return stan;
        }

        public static bool UsunOddzialZBazy(sbyte idOddzialu)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_ODDZIAL = $"DELETE FROM oddzialy WHERE id_oddzialu={idOddzialu}";

                MySqlCommand command = new MySqlCommand(USUN_ODDZIAL, connection);
                connection.Open();
                var delete = command.ExecuteNonQuery();
                if(delete == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        #endregion
    }
}

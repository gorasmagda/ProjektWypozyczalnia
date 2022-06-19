using System.Collections.Generic;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;

    class RepozytoriumPracownicy
    {

        #region ZAPYTANIA
        private const string WSZYSCY_PRACOWNICY = "SELECT * FROM pracownicy";
        private const string DODAJ_PRACOWNIKA = "INSERT INTO pracownicy VALUES ";
        #endregion

        #region metody CRUD
        public static List<Pracownik> PobierzWszystkichPracownikow(IDBConnection database)
        {
            List<Pracownik> pracownicy = new List<Pracownik>();

            using (var connection = database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_PRACOWNICY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    pracownicy.Add(new Pracownik(reader));
                connection.Close();

            }
            return pracownicy;
        }

        public static bool DodajPracownikaDoBazy(IDBConnection database, Pracownik pracownik)
        {
            bool stan = false;
            using (var connection = database.GetConnection())
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_PRACOWNIKA} {pracownik.ToInsert()}", connection);
                connection.Open();
                var reader = command.ExecuteNonQuery();
                stan = true;
                pracownik.IdPracownik = (sbyte)command.LastInsertedId;
                connection.Close();
            }

            return stan;
        }

        public static bool EdytujPracownikaWBazie(IDBConnection database, Pracownik p, sbyte idPracownik)
        {
            bool stan = false;
            using (var connection = database.GetConnection())
            {
                string EDYTUJ_PRACOWNIKA = $"UPDATE pracownicy SET imie='{p.Imie}', nazwisko='{p.Nazwisko}', plec='{p.Plec}', email='{p.Email}', " +
                    $"nr_telefonu='{p.NrTelefonu}', adres='{p.Adres}', pesel='{p.Pesel}', nr_prawa_jazdy='{p.NrPrawaJazdy}', " +
                    $"data_urodzenia='{p.DataUrodzenia:yyyy-MM-dd}', id_oddzialu='{p.IdOddzial}', pensja='{p.Pensja}' WHERE id_pracownik='{idPracownik}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_PRACOWNIKA, connection);
                connection.Open();
                var edit = command.ExecuteNonQuery();
                if (edit == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool UsunPracownikaZBazy(IDBConnection database, sbyte idPracownik)
        {
            bool stan = false;
            using (var connection = database.GetConnection())
            {
                string USUN_PRACOWNIKA = $"DELETE FROM pracownicy WHERE id_pracownik={idPracownik}";

                MySqlCommand command = new MySqlCommand(USUN_PRACOWNIKA, connection);
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

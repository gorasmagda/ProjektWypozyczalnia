using System.Collections.Generic;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;
    using System;

    class RepozytoriumSamochody
    {

        #region ZAPYTANIA
        // samochody (id_auto, marka, model, rocznik, kolor, ilosc_miejsc, skrzynia, nr_rejestracyjny, aktualna_lokalizacja, cena, kaucja, przebieg, dostepnosc, id_oddzialu, nazwa)
        // 'samochody' ('marka', 'model', 'rocznik', 'kolor', 'ilosc_miejsc', 'skrzynia', 'nr_rejestracyjny', 'aktualna_lokalizacja', 'cena', 'kaucja', 'przebieg', 'dostepnosc', 'id_oddzialu', 'nazwa')

        private const string WSZYSTKIE_SAMOCHODY = "SELECT * FROM samochody Order BY ID_AUTO ASC";
        private const string DODAJ_SAMOCHOD = "INSERT INTO samochody ( marka, model, rocznik, kolor, ilosc_miejsc, skrzynia, nr_rejestracyjny, aktualna_lokalizacja, cena, kaucja, przebieg, dostepnosc, id_oddzialu, kategoria) VALUES ";
        private const string SZUKAJ_SAMOCHODOW = "SELECT * FROM samochody WHERE id_auto NOT IN (SELECT id_auto FROM wynajem WHERE";

        #endregion


        #region metody CRUD
        public static List<Samochod> PobierzWszystkieSamochody()
        {
            List<Samochod> samochody = new List<Samochod>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_SAMOCHODY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    samochody.Add(new Samochod(reader));
                connection.Close();
            }

            return samochody;
        }

        public static bool DodajSamochodDoBazy(Samochod samochod)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_SAMOCHOD} {samochod.ToInsert()}", connection);
                connection.Open();
                var add = command.ExecuteNonQuery();
                stan = true;
                samochod.IdAuto = (sbyte)command.LastInsertedId;
                connection.Close();
            }

            return stan;
        }

        public static bool EdytujSamochodWBazie(Samochod s, sbyte idAuta)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_SAMOCHOD = $"UPDATE samochody SET marka='{s.Marka}', model='{s.ModelAuta}', rocznik='{s.Rocznik}', kolor='{s.Kolor}', " +
                    $"ilosc_miejsc='{s.IloscMiejsc}', skrzynia='{s.Skrzynia}', nr_rejestracyjny='{s.NrRejestracyjny}', aktualna_lokalizacja='{s.Lokalizacja}', " +
                    $"cena='{s.Cena}', kaucja='{s.Kaucja}', przebieg='{s.Przebieg}', dostepnosc='{s.Dostepnosc}', id_oddzialu='{s.IdOddzial}', " +
                    $"kategoria='{s.Kategoria}' WHERE id_auto='{idAuta}'";
                
                MySqlCommand command = new MySqlCommand(EDYTUJ_SAMOCHOD, connection);
                connection.Open();
                var edit = command.ExecuteNonQuery();
                if (edit == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool UsunSamochodZBazy(sbyte idAuta)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_SAMOCHOD = $"DELETE FROM samochody WHERE id_auto={idAuta}";

                MySqlCommand command = new MySqlCommand(USUN_SAMOCHOD, connection);
                connection.Open();
                var delete = command.ExecuteNonQuery();
                if (delete == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        public static List<Samochod> PobierzWyszukaneSamochody(DateTime r, DateTime z)
        {
            List<Samochod> samochody = new List<Samochod>();

            using (var connection = DBConnection.Instance.Connection)
            {
                string warunki = $"(data_wypozyczenia < '{r:yyyy-MM-dd}' AND data_zwrotu > '{z:yyyy-MM-dd}') " +
                                 $"OR (data_wypozyczenia > '{r:yyyy-MM-dd}' AND data_zwrotu < '{z:yyyy-MM-dd}') " +
                                 $"OR (data_zwrotu > '{r:yyyy-MM-dd}' AND data_zwrotu < '{z:yyyy-MM-dd}') " +
                                 $"OR (data_wypozyczenia > '{r:yyyy-MM-dd}' AND data_wypozyczenia < '{z:yyyy-MM-dd}'))";
                MySqlCommand command = new MySqlCommand($"{SZUKAJ_SAMOCHODOW} {warunki}", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    samochody.Add(new Samochod(reader));
                connection.Close();
            }
            return samochody;
        }
        //(data_wypozyczenia< '2022-05-25' AND data_zwrotu> '2022-06-25')
        //OR(data_wypozyczenia > '2022-05-25' AND data_zwrotu < '2022-06-25')
        //OR(data_zwrotu > '2022-05-25' AND data_zwrotu < '2022-06-25')
        //OR(data_wypozyczenia > '2022-05-25' AND data_wypozyczenia < '2022-06-25'));
        #endregion

    }
}

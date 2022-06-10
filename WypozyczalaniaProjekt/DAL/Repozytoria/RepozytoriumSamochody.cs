using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;

    class RepozytoriumSamochody
    {

        #region ZAPYTANIA
        private const string WSZYSTKIE_SAMOCHODY = "SELECT * FROM samochody Order BY ID_AUTO ASC";
        private const string DODAJ_SAMOCHOD = "INSERT INTO samochody ( marka, model, rocznik, kolor, ilosc_miejsc, skrzynia, nr_rejestracyjny, aktualna_lokalizacja, cena, kaucja, przebieg, dostepnosc, id_oddzialu, nazwa) VALUES ";
        #endregion

        // samochody (id_auto, marka, model, rocznik, kolor, ilosc_miejsc, skrzynia, nr_rejestracyjny, aktualna_lokalizacja, cena, kaucja, przebieg, dostepnosc, id_oddzialu, nazwa)

        //  'samochody' ('marka', 'model', 'rocznik', 'kolor', 'ilosc_miejsc', 'skrzynia', 'nr_rejestracyjny', 'aktualna_lokalizacja', 'cena', 'kaucja', 'przebieg', 'dostepnosc', 'id_oddzialu', 'nazwa')


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
                Console.WriteLine("Dupa");
                connection.Close();

            }
            return samochody;
        }

        public static bool DodajSamochodDoBazy(Samochod samochod)
        {
            bool stan = false; 
            using(var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_SAMOCHOD} {samochod.ToInsert()}", connection);
                connection.Open();
                var reader = command.ExecuteNonQuery();
                stan = true;
                samochod.IdAuto = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            
            
            return stan;
        }


        #endregion

    }
}

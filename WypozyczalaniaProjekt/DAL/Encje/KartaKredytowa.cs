﻿using MySql.Data.MySqlClient;
using System;


namespace WypozyczalaniaProjekt.DAL.Encje
{
    class KartaKredytowa
    {
        public sbyte? IdKarty { get; set; }
        public string Numer { get; set; }
        public DateTime DataWaznosci { get; set; }
        public string NumerCVV { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Rodzaj { get; set; }

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public KartaKredytowa(MySqlDataReader reader)
        {
            IdKarty = sbyte.Parse(reader["id_karta"].ToString());
            Numer = reader["numer"].ToString();
            DataWaznosci = DateTime.Parse(reader["data_waznosci"].ToString());
            NumerCVV = reader["numer_CVV"].ToString();
            Imie = reader["imie"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Rodzaj = reader["rodzaj"].ToString();

        }

        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public KartaKredytowa(string numer, DateTime dataWaznosci, string numerCVV, string imie, string nazwisko, string rodzaj)
        {
            IdKarty = null;
            Numer = numer.Trim();
            DataWaznosci = dataWaznosci;
            NumerCVV = NumerCVV.Trim();
            Imie = imie.Trim();
            Nazwisko = nazwisko.Trim();
            Rodzaj = rodzaj.Trim();
        }

        public KartaKredytowa(KartaKredytowa kartykredytowe)
        {
            IdKarty = kartykredytowe.IdKarty;
            Numer = kartykredytowe.Numer;
            DataWaznosci = kartykredytowe.DataWaznosci;
            NumerCVV = kartykredytowe.Numer;
            Imie = kartykredytowe.Imie;
            Nazwisko = kartykredytowe.Nazwisko;
            Rodzaj = kartykredytowe.Rodzaj;
        }
    }
}

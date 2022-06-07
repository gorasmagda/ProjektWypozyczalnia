using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Samochody
    {
        public sbyte? IdAuto { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Rocznik { get; set; }
        public string Kolor { get; set; }
        public int IloscMiejsc { get; set; }
        public string Skrzynia { get; set; }
        public string NrRejestracyjny { get; set; }
        public string AktualnaLokalizacja { get; set; }
        public decimal Cena { get; set; }
        public decimal Kaucja { get; set; }
        public int Przebieg { get; set; }
        public string Dostepnosc { get; set; }
        public sbyte? IdOddzialu { get; set; }
        public string Nazwa { get; set; }

        public Samochody(MySqlDataReader reader)
        {
            IdAuto = sbyte.Parse(reader["id_auto"].ToString());
            Marka = reader["marka"].ToString();
            Model = reader["model"].ToString();
            Rocznik = int.Parse(reader["rocznik"].ToString());
            Kolor = reader["kolor"].ToString();
            IloscMiejsc = int.Parse(reader["ilosc_miejsc"].ToString());
            Skrzynia = reader["skrzynia"].ToString();
            NrRejestracyjny = reader["nr_rejestracyjny"].ToString();
            AktualnaLokalizacja = reader["aktualna_lokalizacja"].ToString();
            Cena = decimal.Parse(reader["cena"].ToString());
            Kaucja = decimal.Parse(reader["kaucja"].ToString());
            Przebieg = int.Parse(reader["przebieg"].ToString());
            Dostepnosc = reader["dostepnosc"].ToString();
            IdOddzialu = sbyte.Parse(reader["id_oddzialu"].ToString());
            Nazwa = reader["nazwa"].ToString();
        }
    }
}

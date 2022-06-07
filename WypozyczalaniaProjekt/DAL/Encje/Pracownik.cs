using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Pracownik
    {
        public sbyte? IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Plec { get; set; }
        public string Email { get; set; }
        public string NrTelefonu { get; set; }
        public string Adres { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public string NrPrawaJazdy { get; set; }
        
        public sbyte? IdOddzial { get; set; }
        public decimal Pensja { get; set; }


        public Pracownik(MySqlDataReader reader)
        {
            IdPracownik = sbyte.Parse(reader["id_pracownik"].ToString());
            Imie = reader["imie"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Plec = reader["plec"].ToString();
            Email = reader["email"].ToString();
            NrTelefonu = reader["nr_telefonu"].ToString();
            Adres = reader["adres"].ToString();
            Pesel = reader["pesel"].ToString();
            NrPrawaJazdy = reader["nr_prawa_jazdy"].ToString();
            DataUrodzenia = DateTime.Parse(reader["data_urodzenia"].ToString());
            IdOddzial = sbyte.Parse(reader["id_oddzialu"].ToString());
            Pensja = decimal.Parse(reader["pensja"].ToString());

        }

        public Pracownik(string imie, string nazwisko, string plec, string email, string nrtelefonu, string adres, string pesel, string nrprawajazdy, DateTime dataurodzenia, sbyte idoddzialu, decimal pensja)
        {
            IdPracownik = null;
            Imie = imie.Trim();
            Nazwisko = nazwisko.Trim();
            Plec = plec.Trim();
            Email = email.Trim();
            NrTelefonu = nrtelefonu.Trim();
            Adres = adres.Trim();
            Pesel = pesel.Trim();
            NrPrawaJazdy = nrprawajazdy.Trim();
            DataUrodzenia = dataurodzenia;
            IdOddzial = idoddzialu;
            Pensja = pensja;
        }

        public Pracownik(Pracownik pracownik)
        {
            IdPracownik = pracownik.IdPracownik;
            Imie = pracownik.Imie;
            Nazwisko = pracownik.Nazwisko;
            Plec = pracownik.Plec;
            Email = pracownik.Email;
            NrTelefonu = pracownik.NrTelefonu;
            Adres = pracownik.Adres;
            Pesel = pracownik.Pesel;
            NrPrawaJazdy = pracownik.NrPrawaJazdy;
            DataUrodzenia = pracownik.DataUrodzenia;
            IdOddzial = pracownik.IdOddzial;
            Pensja = pracownik.Pensja;
        }
    }
}


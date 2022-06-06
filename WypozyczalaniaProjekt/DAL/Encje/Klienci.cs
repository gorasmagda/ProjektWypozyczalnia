using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Klienci
    {
        public sbyte? IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Plec { get; set; }
        public string Email { get; set; }
        public string NrTelefonu { get; set; }
        public string Adres { get; set; }
        public string Pesel { get; set; }
        public string NrPrawaJazdy { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public sbyte? IdKarty { get; set; }


        public Klienci(MySqlDataReader reader)
        {
            IdKlient = sbyte.Parse(reader["id_klient"].ToString());
            Imie = reader["imie"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Plec = reader["plec"].ToString();
            Email = reader["email"].ToString();
            NrTelefonu = reader["nr_telefonu"].ToString();
            Adres = reader["adres"].ToString(); 
            Pesel = reader["pesel"].ToString();
            NrPrawaJazdy = reader["nr_prawa_jazdy"].ToString();
            DataUrodzenia = DateTime.Parse(reader["data_urodzenia"].ToString());
            IdKarty = sbyte.Parse(reader["id_karta"].ToString());

        }

        public Klienci(string imie, string nazwisko, string plec, string email, string nrtelefonu, string adres, string pesel, string nrprawajazdy, DateTime dataurodzenia, sbyte idkarty)
        {
            IdKlient = null;
            Imie = imie.Trim();
            Nazwisko = nazwisko.Trim();
            Plec = plec.Trim();
            Email = email.Trim();
            NrTelefonu = nrtelefonu.Trim();
            Adres = adres.Trim();
            Pesel = pesel.Trim();
            NrPrawaJazdy = nrprawajazdy.Trim();
            DataUrodzenia = dataurodzenia;
            IdKarty = idkarty;
        }

        public Klienci(Klienci klient)
        {
            IdKlient = klient.IdKarty;
            Imie = klient.Imie;
            Nazwisko = klient.Nazwisko;
            Plec = klient.Plec;
            Email = klient.Email;
            NrTelefonu = klient.NrTelefonu;
            Adres = klient.Adres;
            Pesel = klient.Pesel;
            NrPrawaJazdy = klient.NrPrawaJazdy;
            DataUrodzenia = klient.DataUrodzenia;
            IdKarty = klient.IdKarty;
        }
    }
}

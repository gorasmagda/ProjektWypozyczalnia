using MySql.Data.MySqlClient;
using System;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Klient
    {

        #region Własności

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

        #endregion

        #region Konstruktory

        public Klient(MySqlDataReader reader)
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

        public Klient(string imie, string nazwisko, string plec, string email, string nrtelefonu, string adres, string pesel, string nrprawajazdy, DateTime dataurodzenia, sbyte idkarty)
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

        public Klient(Klient klient)
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

        #endregion

        #region Metody

        public override string ToString()
        {
            return IdKlient + ", " + Imie + ", " + Nazwisko + ", " + NrTelefonu + ", " + Email;
        }

        public string ToInsert()
        {
            return $"(0,'{Imie}','{Nazwisko}','{Plec}','{Email}',{NrTelefonu},'{Adres}','{Pesel}','{NrPrawaJazdy}','{DataUrodzenia:yyyy-MM-dd}','{IdKarty}')";
        }

        public override bool Equals(object obj)
        {
            var klient = obj as Klient;
            if (klient is null) return false;
            if (Imie.ToLower() != klient.Imie.ToLower()) return false;
            if (Nazwisko.ToLower() != klient.Nazwisko.ToLower()) return false;
            if (!Plec.ToLower().Equals(klient.Plec.ToLower())) return false;
            if (!Email.ToLower().Equals(klient.Email.ToLower())) return false;
            if (!NrTelefonu.ToLower().Equals(klient.NrTelefonu.ToLower())) return false;
            if (!Adres.ToLower().Equals(klient.Adres.ToLower())) return false;
            if (!Pesel.ToLower().Equals(klient.Pesel.ToLower())) return false;
            if (!NrPrawaJazdy.ToLower().Equals(klient.NrPrawaJazdy.ToLower())) return false;
            if (!DataUrodzenia.Equals(klient.DataUrodzenia)) return false;
            if (!IdKarty.Equals(klient.IdKarty)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}

using MySql.Data.MySqlClient;
using System;


namespace WypozyczalaniaProjekt.DAL.Encje
{
    class KartaKredytowa
    {

        #region Własności

        public sbyte? IdKarty { get; set; }
        public string Numer { get; set; }
        public DateTime DataWaznosci { get; set; }
        public string NumerCVV { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Rodzaj { get; set; }

        #endregion

        #region Konstruktory

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

        public KartaKredytowa(string numer, DateTime dataWaznosci, string numerCVV, string imie, string nazwisko, string rodzaj)
        {
            IdKarty = null;
            Numer = numer.Trim();
            DataWaznosci = dataWaznosci;
            NumerCVV = numerCVV.Trim();
            Imie = imie.Trim();
            Nazwisko = nazwisko.Trim();
            Rodzaj = rodzaj.Trim();
        }

        public KartaKredytowa(KartaKredytowa kartykredytowe)
        {
            IdKarty = kartykredytowe.IdKarty;
            Numer = kartykredytowe.Numer;
            DataWaznosci = kartykredytowe.DataWaznosci;
            NumerCVV = kartykredytowe.NumerCVV;
            Imie = kartykredytowe.Imie;
            Nazwisko = kartykredytowe.Nazwisko;
            Rodzaj = kartykredytowe.Rodzaj;
        }

        #endregion

        #region Metody

        public string ToInsert()
        {
            return $"(0,'{Numer}','{DataWaznosci:yyyy-MM-dd}','{NumerCVV}','{Imie}','{Nazwisko}','{Rodzaj}')";
        }

        public override bool Equals(object obj)
        {
            var karta = obj as KartaKredytowa;
            if (karta is null) return false;
            if (Numer.ToLower() != karta.Numer.ToLower()) return false;
            if (!DataWaznosci.Equals(karta.DataWaznosci)) return false;
            if (!NumerCVV.ToLower().Equals(karta.NumerCVV.ToLower())) return false;
            if (!Imie.ToLower().Equals(karta.Imie.ToLower())) return false;
            if (!Nazwisko.ToLower().Equals(karta.Nazwisko.ToLower())) return false;
            if (!Rodzaj.ToLower().Equals(karta.Rodzaj.ToLower())) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}

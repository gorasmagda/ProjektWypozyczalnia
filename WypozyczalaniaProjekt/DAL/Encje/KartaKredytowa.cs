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
            NumerCVV = kartykredytowe.Numer;
            Imie = kartykredytowe.Imie;
            Nazwisko = kartykredytowe.Nazwisko;
            Rodzaj = kartykredytowe.Rodzaj;
        }

        #endregion

        #region Metody

        public string ToInsert()
        {
            return $"(0,'{Numer}','{DataWaznosci}','{NumerCVV}','{Imie}','{Nazwisko}','{Rodzaj}')";
        }

        #endregion

    }
}

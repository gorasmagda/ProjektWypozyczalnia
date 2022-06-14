using MySql.Data.MySqlClient;
using System;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Wynajem
    {

        #region Własności

        public sbyte? IdWynajem { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataZwrotu { get; set; }
        public decimal CalkowityKoszt { get; set; }
        public sbyte? IdAuto { get; set; }
        public sbyte? IdKlient { get; set; }
        public sbyte? IdPracownik { get; set; }

        #endregion

        #region Konstruktory

        public Wynajem(MySqlDataReader reader)
        {
            IdWynajem = sbyte.Parse(reader["id_wynajem"].ToString());
            DataWypozyczenia = DateTime.Parse(reader["data_wypozyczenia"].ToString());
            DataZwrotu = DateTime.Parse(reader["data_zwrotu"].ToString());
            CalkowityKoszt = decimal.Parse(reader["calkowity_koszt"].ToString());
            IdAuto = sbyte.Parse(reader["id_auto"].ToString());
            IdKlient = sbyte.Parse(reader["id_klient"].ToString());
            IdPracownik = sbyte.Parse(reader["id_pracownik"].ToString());
        }

        public Wynajem(sbyte? idWynajem, DateTime dataWypozyczenia, DateTime dataZwrotu, decimal calkowityKoszt, sbyte? idAuto, sbyte? idKlient, sbyte? idPracownik)
        {
            IdWynajem = null;
            DataWypozyczenia = dataWypozyczenia;
            DataZwrotu = dataZwrotu;
            CalkowityKoszt = calkowityKoszt;
            IdAuto = idAuto;
            IdKlient = idKlient;
            IdPracownik = idPracownik;
        }

        public Wynajem(Wynajem wynajem)
        {
            IdWynajem = wynajem.IdWynajem;
            DataWypozyczenia = wynajem.DataWypozyczenia;
            DataZwrotu = wynajem.DataZwrotu;
            CalkowityKoszt = wynajem.CalkowityKoszt;
            IdAuto = wynajem.IdAuto;
            IdKlient = wynajem.IdKlient;
            IdPracownik = wynajem.IdPracownik;
        }

        #endregion

        #region Metody



        #endregion
    }
}

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
        public string StatusTransakcji { get; set; }

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
            StatusTransakcji = reader["status_transakcji"].ToString();
        }

        public Wynajem(DateTime dataWypozyczenia, DateTime dataZwrotu, decimal calkowityKoszt, sbyte? idAuto, sbyte? idKlient, sbyte? idPracownik, string statusTransakcji)
        {
            IdWynajem = null;
            DataWypozyczenia = dataWypozyczenia;
            DataZwrotu = dataZwrotu;
            CalkowityKoszt = calkowityKoszt;
            IdAuto = idAuto;
            IdKlient = idKlient;
            IdPracownik = idPracownik;
            StatusTransakcji = statusTransakcji;
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
            StatusTransakcji = wynajem.StatusTransakcji;
        }

        #endregion

        #region Metody

        public string ToInsert()
        {
            return $"(0, '{DataWypozyczenia:yyyy-MM-dd}', '{DataZwrotu:yyyy-MM-dd}','{CalkowityKoszt}','{IdAuto}','{IdKlient}','{IdPracownik}','{StatusTransakcji}')";
        }

        public override bool Equals(object obj)
        {
            var wynajem = obj as Wynajem;
            if (wynajem is null) return false;
            if (DataWypozyczenia != wynajem.DataWypozyczenia) return false;
            if (!DataZwrotu.Equals(wynajem.DataZwrotu)) return false;
            if (!CalkowityKoszt.Equals(wynajem.CalkowityKoszt)) return false;
            if (!IdAuto.Equals(wynajem.IdAuto)) return false;
            if (!IdKlient.Equals(wynajem.IdKlient)) return false;
            if (!IdPracownik.Equals(wynajem.IdPracownik)) return false;
            if (!StatusTransakcji.ToLower().Equals(wynajem.StatusTransakcji.ToLower())) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}

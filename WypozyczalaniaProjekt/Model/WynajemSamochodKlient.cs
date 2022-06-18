using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.Model
{
    class WynajemSamochodKlient
    {
        public sbyte? IdWynajem { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataZwrotu { get; set; }
        public decimal CalkowityKoszt { get; set; }
        public sbyte? IdAuto { get; set; }
        public sbyte? IdKlient { get; set; }
        public sbyte? IdPracownik { get; set; }
        public string Marka { get; set; }
        public string ModelAuta { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string StatusTransakcji { get; set; }

        public WynajemSamochodKlient(sbyte? idWynajem, DateTime dataWypozyczenia, DateTime dataZwrotu, decimal calkowityKoszt, sbyte? idAuto, sbyte? idKlient, sbyte? idPracownik, string marka, string modelAuta, string nazwisko, string imie, string status)
        {
            IdWynajem = idWynajem;
            DataWypozyczenia = dataWypozyczenia;
            DataZwrotu = dataZwrotu;
            CalkowityKoszt = calkowityKoszt;
            IdAuto = idAuto;
            IdKlient = idKlient;
            IdPracownik = idPracownik;
            Marka = marka;
            ModelAuta = modelAuta;
            Nazwisko = nazwisko;
            Imie = imie;
            StatusTransakcji = status;
        }

    }
}

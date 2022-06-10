using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;

    class Model
    {

        public ObservableCollection<Samochod> Samochody { get; set; } = new ObservableCollection<Samochod>();
        public ObservableCollection<Klient> Klienci { get; set; } = new ObservableCollection<Klient>();

        public ObservableCollection<Pracownik> Pracownicy { get; set; } = new ObservableCollection<Pracownik>();
 
        public Model()
        {
            //pobranie dabych z bazy do kolekcji
            var samochody = RepozytoriumSamochody.PobierzWszystkieSamochody();
            foreach (var s in samochody)
                Samochody.Add(s);

            var klienci = RepozytoriumKlienci.PobierzWszystkichKlientow();
            foreach (var k in klienci)
                Klienci.Add(k);

            var pracownicy = RepozytoriumPracownicy.PobierzWszystkichPracownikow();
            foreach (var p in pracownicy)
                Pracownicy.Add(p);

        }


        public bool CzySamochodJestJuzWBazie(Samochod samochod) => Samochody.Contains(samochod);
        public bool DodajSamochodDoBazy(Samochod samochod)
        {
            if (!CzySamochodJestJuzWBazie(samochod))
            {
                if (RepozytoriumSamochody.DodajSamochodDoBazy(samochod))
                {
                    Samochody.Add(samochod);
                    return true;
                }
            }
            return false; 
        }
    }
}

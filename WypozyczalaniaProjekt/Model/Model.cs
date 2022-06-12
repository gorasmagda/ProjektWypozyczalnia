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
            //pobranie danych z bazy do kolekcji
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

        private bool CzySamochodJestJuzWBazie(Samochod samochod) => Samochody.Contains(samochod);
        private bool CzyPracownikJestJuzWBazie(Pracownik pracownik) => Pracownicy.Contains(pracownik);
        private bool CzyKlientJestJuzWBazie(Klient klient) => Klienci.Contains(klient);

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

        public bool EdytujSamochodWBazie(Samochod samochod, sbyte idAuta)
        {
            if (RepozytoriumSamochody.EdytujSamochodWBazie(samochod, idAuta))
            {
                for (int i=0; i<Samochody.Count; i++)
                {
                    if (Samochody[i].IdAuto == idAuta)
                    {
                        samochod.IdAuto = idAuta;
                        Samochody[i] = new Samochod(samochod);
                    }
                }
                return true;
            }
            return false;
        }

        public bool UsunSamochodZBazy(sbyte idAuta)
        {
            if (RepozytoriumSamochody.UsunSamochodZBazy(idAuta))
            {
                for (int i = 0; i < Samochody.Count; i++)
                {
                    if (Samochody[i].IdAuto == idAuta)
                    {
                        Samochody.RemoveAt(i);
                    }
                }
                return true;
            }
            return false;
        }
        public bool DodajPracownikaDoBazy(Pracownik pracownik)
        {
            if (!CzyPracownikJestJuzWBazie(pracownik))
            {
                if (RepozytoriumPracownicy.DodajPracownikaDoBazy(pracownik))
                {
                    Pracownicy.Add(pracownik);
                    return true;
                }
            }
            return false;
        }

        public bool DodajKlientaDoBazy(Klient klient)
        {
            if (!CzyKlientJestJuzWBazie(klient))
            {
                if (RepozytoriumKlienci.DodajKlientaDoBazy(klient))
                {
                    Klienci.Add(klient);
                    return true;
                }
            }
            return false;
        }

    }
}

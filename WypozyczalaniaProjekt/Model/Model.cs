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
        public ObservableCollection<Oddzial> Oddzialy { get; set; } = new ObservableCollection<Oddzial>();
        public ObservableCollection<Kategoria> Kategorie { get; set; } = new ObservableCollection<Kategoria>();

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

            var oddzialy = RepozytoriumOddzialy.PobierzWszystkieOddzialy();
            foreach (var o in oddzialy)
                Oddzialy.Add(o);

            var kategorie = RepozytoriumKategorie.PobierzWszystkieKategorie();
            foreach (var k in kategorie)
                Kategorie.Add(k);
        }

        private bool CzySamochodJestJuzWBazie(Samochod samochod) => Samochody.Contains(samochod);
        private bool CzyPracownikJestJuzWBazie(Pracownik pracownik) => Pracownicy.Contains(pracownik);
        private bool CzyKlientJestJuzWBazie(Klient klient) => Klienci.Contains(klient);
        private bool CzyOddzialJestJuzWBazie(Oddzial oddzial) => Oddzialy.Contains(oddzial);

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

        public bool EdytujPracownikaWBazie(Pracownik pracownik, sbyte idPracownik)
        {
            if (RepozytoriumPracownicy.EdytujPracownikaWBazie(pracownik, idPracownik))
            {
                for (int i = 0; i < Pracownicy.Count; i++)
                {
                    if (Pracownicy[i].IdPracownik == idPracownik)
                    {
                        pracownik.IdPracownik = idPracownik;
                        Pracownicy[i] = new Pracownik(pracownik);
                    }
                }
                return true;
            }
            return false;
        }

        public bool UsunPracownikaZBazy(sbyte idPracownik)
        {
            if (RepozytoriumPracownicy.UsunPracownikaZBazy(idPracownik))
            {
                for (int i = 0; i < Pracownicy.Count; i++)
                {
                    if (Pracownicy[i].IdPracownik == idPracownik)
                    {
                        Pracownicy.RemoveAt(i);
                    }
                }
                return true;
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

        public bool EdytujKlientaWBazie(Klient klient, sbyte idKlient)
        {
            if (RepozytoriumKlienci.EdytujKlientaWBazie(klient, idKlient))
            {
                for (int i = 0; i < Klienci.Count; i++)
                {
                    if (Klienci[i].IdKlient == idKlient)
                    {
                        klient.IdKlient = idKlient;
                        Klienci[i] = new Klient(klient);
                    }
                }
                return true;
            }
            return false;
        }

        public bool UsunKlientaZBazy(sbyte idKlient)
        {
            if (RepozytoriumKlienci.UsunKlientaZBazy(idKlient))
            {
                for (int i = 0; i < Klienci.Count; i++)
                {
                    if (Klienci[i].IdKlient == idKlient)
                    {
                        Klienci.RemoveAt(i);
                    }
                }
                return true;
            }
            return false;
        }

        public bool DodajOddzialDoBazy(Oddzial oddzial)
        {
            if (!CzyOddzialJestJuzWBazie(oddzial))
            {
                if (RepozytoriumOddzialy.DodajOddzialDoBazy(oddzial))
                {
                    Oddzialy.Add(oddzial);
                    return true;
                }
            }
            return false;
        }

        public bool EdytujOddzialWBazie(Oddzial oddzial, sbyte idOddzialu)
        {
            if (RepozytoriumOddzialy.EdytujOddzialWBazie(oddzial, idOddzialu))
            {
                for (int i = 0; i < Oddzialy.Count; i++)
                {
                    if (Oddzialy[i].IdOddzialu == idOddzialu)
                    {
                        oddzial.IdOddzialu = idOddzialu;
                        Oddzialy[i] = new Oddzial(oddzial);
                    }
                }
                return true;
            }
            return false;
        }

        public bool UsunOddzialZBazy(sbyte idOddzialu)
        {
            if (RepozytoriumOddzialy.UsunOddzialZBazy(idOddzialu))
            {
                for (int i = 0; i < Oddzialy.Count; i++)
                {
                    if (Oddzialy[i].IdOddzialu == idOddzialu)
                    {
                        Oddzialy.RemoveAt(i);
                    }
                }
                return true;
            }
            return false;
        }
    }
}

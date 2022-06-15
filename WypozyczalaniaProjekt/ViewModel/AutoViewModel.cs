namespace WypozyczalaniaProjekt.ViewModel
{
    using BaseClassess;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;

    class AutoViewModel : ViewModelBase
    {

        #region Składowe prywatne

        private Model model = null;

        private int idWybranegoAuta;
        private int? rocznik, iloscMiejsc, przebieg, idOddzial;
        private string kaucja, lokalizacja, modelAuta, nrRejestracyjny, cena, dostepnosc, marka, kolor, skrzynia;
        private Kategoria wybranaKategoria;
        private Oddzial wybranyOddzial;

        #endregion

        #region Konstruktory

        public AutoViewModel(Model model)
        {
            Samochody = new ObservableCollection<Samochod>();
            Oddzialy = new ObservableCollection<Oddzial>();
            Kategorie = new ObservableCollection<Kategoria>();
            this.model = model;
            Samochody = model.Samochody;
            Oddzialy = model.Oddzialy;
            Kategorie = model.Kategorie;
            idWybranegoAuta = -1;
        }

        #endregion

        #region Właściwości

        public ObservableCollection<Samochod> Samochody { get; set; }
        public ObservableCollection<Oddzial> Oddzialy { get; set; }
        public ObservableCollection<Kategoria> Kategorie { get; set; }
        public Samochod WybraneAuto { get; set; }

        public int IdWybranegoAuta
        {
            get => idWybranegoAuta;
            set
            {
                idWybranegoAuta = value;
                onPropertyChanged(nameof(IdWybranegoAuta));
            }
        }

        public string Kaucja
        {
            get => kaucja;
            set
            {
                kaucja = value;
                onPropertyChanged(nameof(Kaucja));
            }
        }

        public string Lokalizacja
        {
            get => lokalizacja;
            set
            {
                lokalizacja = value;
                onPropertyChanged(nameof(Lokalizacja));
            }
        }

        public string ModelAuta
        {
            get => modelAuta;
            set
            {
                modelAuta = value;
                onPropertyChanged(nameof(ModelAuta));
            }
        }

        public int? Rocznik
        {
            get => rocznik;
            set
            {
                rocznik = value;
                onPropertyChanged(nameof(Rocznik));
            }
        }

        public int? IloscMiejsc
        {
            get => iloscMiejsc;
            set
            {
                iloscMiejsc = value;
                onPropertyChanged(nameof(IloscMiejsc));
            }
        }

        public int? Przebieg
        {
            get => przebieg;
            set
            {
                przebieg = value;
                onPropertyChanged(nameof(Przebieg));
            }
        }

        public string NrRejestracyjny
        {
            get => nrRejestracyjny;
            set
            {
                nrRejestracyjny = value;
                onPropertyChanged(nameof(NrRejestracyjny));
            }
        }

        public string Cena
        {
            get => cena;
            set
            {
                cena = value;
                onPropertyChanged(nameof(Cena));
            }
        }

        public string Dostepnosc
        {
            get => dostepnosc;
            set
            {
                dostepnosc = value;
                onPropertyChanged(nameof(Dostepnosc));
            }
        }

        public string Marka
        {
            get => marka;
            set
            {
                marka = value;
                onPropertyChanged(nameof(Marka));
            }
        }

        public string Kolor
        {
            get => kolor;
            set
            {
                kolor = value;
                onPropertyChanged(nameof(Kolor));
            }
        }

        public string Skrzynia
        {
            get => skrzynia;
            set
            {
                skrzynia = value;
                onPropertyChanged(nameof(Skrzynia));
            }
        }

        public Oddzial WybranyOddzial
        {
            get => wybranyOddzial;
            set
            {
                wybranyOddzial = value;
                onPropertyChanged(nameof(WybranyOddzial));
            }
        }

        public Kategoria WybranaKategoria
        {
            get => wybranaKategoria;
            set
            {
                wybranaKategoria = value;
                onPropertyChanged(nameof(WybranaKategoria));
            }
        }

        #endregion

        #region Polecenia

        private ICommand dodajAuto = null;
        public ICommand DodajAuto
        {
            get
            {
                if (dodajAuto == null)
                    dodajAuto = new RelayCommand(
                        arg =>
                        {
                            var samochod = new Samochod(Marka, ModelAuta, (int)Rocznik, Kolor, (int)IloscMiejsc, Skrzynia, NrRejestracyjny, Lokalizacja, Cena, Kaucja, (int)Przebieg, Dostepnosc, (sbyte)WybranyOddzial.IdOddzialu, WybranaKategoria.Nazwa);
                            if (model.DodajSamochodDoBazy(samochod))
                            {
                                CzyscFormularz();
                                MessageBox.Show("Samochod został dodany!");
                            }
                        },
                        arg => SprawdzFormularz()); // TODO: AutoVM - walidacja danych
                return dodajAuto;
            }

        }

        private ICommand edytujAuto = null;
        public ICommand EdytujAuto
        {
            get
            {
                if (edytujAuto == null)
                    edytujAuto = new RelayCommand(
                        arg =>
                        {
                            model.EdytujSamochodWBazie(new Samochod(Marka, ModelAuta, (int)Rocznik, Kolor, (int)IloscMiejsc, Skrzynia, NrRejestracyjny, Lokalizacja, Cena, Kaucja, (int)Przebieg, Dostepnosc, (sbyte)WybranyOddzial.IdOddzialu, WybranaKategoria.Nazwa), (sbyte)WybraneAuto.IdAuto);
                            IdWybranegoAuta = -1;
                        },
                        arg => IdWybranegoAuta > -1);  // TODO: AutoVM - Edycja Auta - walidacja
                return edytujAuto;
            }
        }

        private ICommand usunAuto = null;
        public ICommand UsunAuto
        {
            get
            {
                if (usunAuto == null)
                    usunAuto = new RelayCommand(
                        arg =>
                        {
                            model.UsunSamochodZBazy((sbyte)WybraneAuto.IdAuto);
                            IdWybranegoAuta = -1;
                        },
                        arg => IdWybranegoAuta > -1);
                return usunAuto;
            }
        }

        private ICommand zaladujFormularz = null;
        public ICommand ZaladujFormularz
        {
            get
            {
                if (zaladujFormularz == null)
                    zaladujFormularz = new RelayCommand(
                        o =>
                        {
                            if (IdWybranegoAuta > -1)
                            {
                                Marka = WybraneAuto.Marka;
                                Kaucja = WybraneAuto.Kaucja;
                                Lokalizacja = WybraneAuto.Lokalizacja;
                                ModelAuta = WybraneAuto.ModelAuta;
                                Rocznik = WybraneAuto.Rocznik;
                                IloscMiejsc = WybraneAuto.IloscMiejsc;
                                Przebieg = WybraneAuto.Przebieg;
                                NrRejestracyjny = WybraneAuto.NrRejestracyjny;
                                Cena = WybraneAuto.Cena;
                                Dostepnosc = WybraneAuto.Dostepnosc;
                                Kolor = WybraneAuto.Kolor;
                                Skrzynia = WybraneAuto.Skrzynia;
                                foreach (var oddzial in Oddzialy)
                                {
                                    if (oddzial.IdOddzialu == (int)WybraneAuto.IdOddzial)
                                    {
                                        WybranyOddzial = oddzial;
                                    }
                                }
                                foreach (var kategoria in Kategorie)
                                {
                                    if (kategoria.Nazwa == WybraneAuto.Kategoria)
                                    {
                                        WybranaKategoria = kategoria;
                                    }
                                }
                            }
                            else
                            {
                                CzyscFormularz();
                            }
                        },
                        null);
                return zaladujFormularz;
            }
        }

        private ICommand wyczysc = null;
        public ICommand Wyczysc
        {
            get
            {
                if (wyczysc == null)
                    wyczysc = new RelayCommand(
                        arg =>
                        {
                            CzyscFormularz();
                        },
                        null);
                return wyczysc;
            }
        }

        #endregion

        private void CzyscFormularz()
        {
            Marka = "";
            Kaucja = "";
            Lokalizacja = "";
            ModelAuta = "";
            Rocznik = null;
            IloscMiejsc = null;
            Przebieg = null;
            NrRejestracyjny = "";
            Cena = null;
            Dostepnosc = "";
            Kolor = "";
            Skrzynia = "";
            WybranyOddzial = null;
            WybranaKategoria = null;
        }

        private bool SprawdzFormularz()
        {
            bool wynik = true;
            // private int? rocznik, iloscMiejsc, przebieg, idOddzial;
            // private string kaucja, lokalizacja, modelAuta, nrRejestracyjny, cena, dostepnosc, marka, kolor, skrzynia, kategoria;

            if (Rocznik == null || IloscMiejsc == null || Przebieg == null || WybranyOddzial == null || WybranaKategoria == null)
                wynik = false;
            if (Kaucja == "" || Lokalizacja == "" || ModelAuta == "" || NrRejestracyjny == "" ||
                Cena == "" || Dostepnosc == "" || Marka == "" || Kolor == "" || Skrzynia == "")
                wynik = false;

            return wynik;
        }
    }
}

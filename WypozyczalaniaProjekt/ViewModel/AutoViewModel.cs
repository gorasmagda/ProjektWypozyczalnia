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
        private int? rocznik, iloscMiejsc, przebieg;
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
            Dostepnosci = new List<string>();
            Skrzynie = new List<string>();
            Dostepnosci.Add("tak");
            Dostepnosci.Add("nie");
            Skrzynie.Add("manualna");
            Skrzynie.Add("automatyczna");

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
        public List<string> Dostepnosci { get; set; }
        public List<string> Skrzynie { get; set; }

        private Samochod wybraneAuto;
        public Samochod WybraneAuto
        {
            get => wybraneAuto;
            set
            {
                wybraneAuto = value;
                if (wybraneAuto != null)
                {
                    DeleteEnabled = true;
                }
                else
                {
                    DeleteEnabled = false;
                }
                onPropertyChanged(nameof(WybraneAuto));
            }
        }

        public int IdWybranegoAuta
        {
            get => idWybranegoAuta;
            set
            {
                idWybranegoAuta = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(IdWybranegoAuta));
            }
        }

        public string Kaucja
        {
            get => kaucja;
            set
            {
                kaucja = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Kaucja));
            }
        }

        public string Lokalizacja
        {
            get => lokalizacja;
            set
            {
                lokalizacja = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Lokalizacja));
            }
        }

        public string ModelAuta
        {
            get => modelAuta;
            set
            {
                modelAuta = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(ModelAuta));
            }
        }

        public int? Rocznik
        {
            get => rocznik;
            set
            {
                rocznik = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Rocznik));
            }
        }

        public int? IloscMiejsc
        {
            get => iloscMiejsc;
            set
            {
                iloscMiejsc = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(IloscMiejsc));
            }
        }

        public int? Przebieg
        {
            get => przebieg;
            set
            {
                przebieg = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Przebieg));
            }
        }

        public string NrRejestracyjny
        {
            get => nrRejestracyjny;
            set
            {
                nrRejestracyjny = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(NrRejestracyjny));
            }
        }

        public string Cena
        {
            get => cena;
            set
            {
                cena = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Cena));
            }
        }

        public string Dostepnosc
        {
            get => dostepnosc;
            set
            {
                dostepnosc = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Dostepnosc));
            }
        }

        public string Marka
        {
            get => marka;
            set
            {
                marka = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Marka));
            }
        }

        public string Kolor
        {
            get => kolor;
            set
            {
                kolor = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Kolor));
            }
        }

        public string Skrzynia
        {
            get => skrzynia;
            set
            {
                skrzynia = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Skrzynia));
            }
        }

        public Oddzial WybranyOddzial
        {
            get => wybranyOddzial;
            set
            {
                wybranyOddzial = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(WybranyOddzial));
            }
        }

        public Kategoria WybranaKategoria
        {
            get => wybranaKategoria;
            set
            {
                wybranaKategoria = value;
                SprawdzFormularz();
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
                            if (MessageBox.Show("Czy chcesz usunąć wybrany samochodów?", "Usuwanie samochodu", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            {
                                if (model.UsunSamochodZBazy((sbyte)WybraneAuto.IdAuto))
                                {
                                    CzyscFormularz();
                                    IdWybranegoAuta = -1;
                                    MessageBox.Show("Usunięto wybrany samochód.");
                                }
                                else
                                {
                                    MessageBox.Show("Usuwanie nie powiodło się");
                                }
                            }
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

        #region Wyłączanie przycisków

        private bool addEnabled, editEnabled, deleteEnabled;
        public bool AddEnabled
        {
            get => addEnabled;
            set
            {
                addEnabled = value;
                onPropertyChanged(nameof(AddEnabled));
            }
        }

        public bool EditEnabled
        {
            get => editEnabled;
            set
            {
                editEnabled = value;
                onPropertyChanged(nameof(EditEnabled));
            }
        }

        public bool DeleteEnabled
        {
            get => deleteEnabled;
            set
            {
                deleteEnabled = value;
                onPropertyChanged(nameof(DeleteEnabled));
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
            WybraneAuto = null;
        }

        private bool SprawdzFormularz() // TODO: WALIDACJA DO EDYCJI AUT
        {
            bool wynik = true;

            if (Rocznik == null || IloscMiejsc == null || Przebieg == null || WybranyOddzial == null || WybranaKategoria == null)
                wynik = false;
            if (Kaucja == "" || Lokalizacja == "" || ModelAuta == "" || NrRejestracyjny == "" ||
                Cena == "" || Dostepnosc == "" || Marka == "" || Kolor == "" || Skrzynia == "")
                wynik = false;

            AddEnabled = wynik;
            EditEnabled = wynik;
            return wynik;
        }
    }
}

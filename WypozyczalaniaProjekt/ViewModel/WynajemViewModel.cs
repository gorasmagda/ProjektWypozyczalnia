using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.ViewModel
{

    using BaseClassess;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;

    class WynajemViewModel : ViewModelBase
    {

        #region Składowe prywatne

        private Model model = null;
        private int idWybranegoWynajmu;
        private string marka, modelAuta, nazwisko, imie;
        private DateTime dataRozpoczecia, dataZakonczenia, rozpoczecieStart, zakonczenieStart;
        private string widocznoscTabeli, widocznoscKalendarza;

        #endregion

        #region Konstruktory

        public WynajemViewModel(Model model)
        {
            this.model = model;
            Wynajmy = new ObservableCollection<Wynajem>();
            WynajmySamochodyKlienci = new ObservableCollection<WynajemSamochodKlient>();
            Samochody = new ObservableCollection<Samochod>();
            Klienci = new ObservableCollection<Klient>();
            Daty = new ObservableCollection<DwieDaty>();
            Wynajmy = model.Wynajmy;
            Samochody = model.Samochody;
            Klienci = model.Klienci;
            IdWybranegoWynajmu = -1;
            DataRozpoczecia = DateTime.Today;
            DataZakonczenia = DateTime.Today;
            RozpoczecieStart = DateTime.Today;
            ZakonczenieStart = DateTime.Today;
            WidocznoscTabeli = "Visible";
            StworzKolekcje();
        }

        #endregion

        #region Właściwości

        public ObservableCollection<Wynajem> Wynajmy { get; set; }
        public ObservableCollection<WynajemSamochodKlient> WynajmySamochodyKlienci { get; set; }
        public ObservableCollection<Samochod> Samochody { get; set; }
        public ObservableCollection<Klient> Klienci { get; set; }
        public ObservableCollection<DwieDaty> Daty { get; set; }

        private Wynajem wybranyWynajem;
        public Wynajem WybranyWynajem
        {
            get => wybranyWynajem;
            set
            {
                wybranyWynajem = value;
                if (wybranyWynajem != null)
                {
                    DeleteEnabled = true;
                }
                else
                {
                    DeleteEnabled = false;
                }
                onPropertyChanged(nameof(WybranyWynajem));
            }
        }

        private Samochod wybranySamochod;
        public Samochod WybranySamochod
        {
            get => wybranySamochod;
            set
            {
                wybranySamochod = value;
                onPropertyChanged(nameof(WybranySamochod));
            }
        }

        private Klient wybranyKlient;
        public Klient WybranyKlient
        {
            get => wybranyKlient;
            set
            {
                wybranyKlient = value;
                onPropertyChanged(nameof(WybranyKlient));
            }
        }

        public int IdWybranegoWynajmu
        {
            get => idWybranegoWynajmu;
            set
            {
                idWybranegoWynajmu = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(IdWybranegoWynajmu));
            }
        }

        public DateTime DataRozpoczecia
        {
            get => dataRozpoczecia;
            set
            {
                dataRozpoczecia = value;
                DataZakonczenia = value;
                ZakonczenieStart = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(DataRozpoczecia));
            }
        }

        public DateTime DataZakonczenia
        {
            get => dataZakonczenia;
            set
            {
                dataZakonczenia = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(DataZakonczenia));
            }
        }

        public DateTime RozpoczecieStart
        {
            get => rozpoczecieStart;
            set
            {
                rozpoczecieStart = value;
                onPropertyChanged(nameof(RozpoczecieStart));
            }
        }

        public DateTime ZakonczenieStart
        {
            get => zakonczenieStart;
            set
            {
                zakonczenieStart = value;
                onPropertyChanged(nameof(ZakonczenieStart));
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

        public string Nazwisko
        {
            get => nazwisko;
            set
            {
                nazwisko = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Nazwisko));
            }
        }

        public string Imie
        {
            get => imie;
            set
            {
                imie = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Imie));
            }
        }

        public string WidocznoscTabeli
        {
            get => widocznoscTabeli;
            set
            {
                widocznoscTabeli = value;
                if (widocznoscTabeli == "Visible")
                {
                    WidocznoscKalendarza = "Collapsed";
                }
                else
                {
                    WidocznoscKalendarza = "Visible";
                }
                onPropertyChanged(nameof(WidocznoscTabeli));
            }
        }

        public string WidocznoscKalendarza
        {
            get => widocznoscKalendarza;
            set
            {
                widocznoscKalendarza = value;
                onPropertyChanged(nameof(widocznoscKalendarza));
            }
        }

        #endregion

        #region Polecenia

        private ICommand szukajAut = null;
        public ICommand SzukajAut
        {
            get
            {
                if (szukajAut == null)
                    szukajAut = new RelayCommand(
                        arg =>
                        {
                            WidocznoscTabeli = "Visible";
                            model.SzukajSamochodow(DataRozpoczecia, DataZakonczenia);
                            Samochody.Clear();
                            foreach (var s in model.WyszukaneSamochody)
                                Samochody.Add(s);
                            MessageBox.Show("Lista dostępnych samochodów została zaktualizowana!");
                        },
                        arg => SprawdzFormularz());
                return szukajAut;
            }
        }

        private ICommand szukajDat = null;
        public ICommand SzukajDat
        {
            get
            {
                if (szukajDat == null)
                    szukajDat = new RelayCommand(
                        arg =>
                        {
                            WidocznoscTabeli = "Collapsed";
                            Daty.Clear();
                            for (int i = 0; i < Wynajmy.Count; i++)
                            {
                                if (Wynajmy[i].IdAuto == WybranySamochod.IdAuto)
                                {
                                    Daty.Add(new DwieDaty(Wynajmy[i].DataWypozyczenia, Wynajmy[i].DataZwrotu));
                                }
                            }
                        },
                        arg => SprawdzFormularz());
                return szukajDat;
            }
        }

        private ICommand przelaczWidok = null;
        public ICommand PrzelaczWidok
        {
            get
            {
                if (przelaczWidok == null)
                    przelaczWidok = new RelayCommand(
                        arg =>
                        {
                            if (WidocznoscTabeli == "Visible")
                            {
                                WidocznoscTabeli = "Collapsed";
                            }
                            else
                            {
                                WidocznoscTabeli = "Visible";
                            }
                        },
                        arg => SprawdzFormularz());
                return przelaczWidok;
            }
        }

        private ICommand resetujTabele = null;
        public ICommand ResetujTabele
        {
            get
            {
                if (resetujTabele == null)
                    resetujTabele = new RelayCommand(
                        arg =>
                        {
                            Samochody.Clear();
                            model.PobierzWszystkieSamochody();
                            foreach (var s in model.Samochody.ToList())
                                Samochody.Add(s);
                        },
                        arg => SprawdzFormularz());
                return resetujTabele;
            }
        }

        private ICommand czyscListe = null;
        public ICommand CzyscListe
        {
            get
            {
                if (czyscListe == null)
                    czyscListe = new RelayCommand(
                        arg =>
                        {
                            Daty.Clear();
                        },
                        arg => SprawdzFormularz());
                return czyscListe;
            }
        }

        private ICommand dodajWynajem = null;
        public ICommand DodajWynajem
        {
            get
            {
                if (dodajWynajem == null)
                    dodajWynajem = new RelayCommand(
                        arg =>
                        {
                            var wynajem = new Wynajem(DataRozpoczecia, DataZakonczenia, 100, WybranySamochod.IdAuto, WybranyKlient.IdKlient, 1);
                            if (model.DodajWynajemDoBazy(wynajem))
                            {
                                CzyscFormularz();
                                WybranyWynajem = null;
                                StworzKolekcje();
                                MessageBox.Show("Wynajem został dodany!");
                            }
                        },
                        arg => SprawdzFormularz());
                return dodajWynajem;
            }
        }

        private ICommand edytujWynajem = null;
        public ICommand EdytujWynajem
        {
            get
            {
                if (edytujWynajem == null)
                    edytujWynajem = new RelayCommand(
                        arg =>
                        {
                            //model.EdytujOddzialWBazie(new Oddzial(Adres, NrTelefonu, Nazwa), (sbyte)WybranyOddzial.IdOddzialu);
                            //CzyscFormularz();
                            //WybranyOddzial = null;
                        },
                        arg => IdWybranegoWynajmu > -1);
                return edytujWynajem;
            }
        }

        private ICommand usunWynajem = null;
        public ICommand UsunWynajem
        {
            get
            {
                if (usunWynajem == null)
                    usunWynajem = new RelayCommand(
                        arg =>
                        {
                            //model.UsunOddzialZBazy((sbyte)WybranyOddzial.IdOddzialu);
                            //IdWybranegoOddzialu = -1;
                        },
                        arg => IdWybranegoWynajmu > -1);
                return usunWynajem;
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
                            // TODO: ZALADOWANIE FORMULARZA
                        },
                        null);
                return zaladujFormularz;
            }
        }

        private ICommand zaladujFormularzAuto = null;
        public ICommand ZaladujFormularzAuto
        {
            get
            {
                if (zaladujFormularzAuto == null)
                    zaladujFormularzAuto = new RelayCommand(
                        o =>
                        {
                            Marka = WybranySamochod.Marka;
                            ModelAuta = WybranySamochod.ModelAuta;
                        },
                        null);
                return zaladujFormularzAuto;
            }
        }

        private ICommand zaladujFormularzKlient = null;
        public ICommand ZaladujFormularzKlient
        {
            get
            {
                if (zaladujFormularzKlient == null)
                    zaladujFormularzKlient = new RelayCommand(
                        o =>
                        {
                            Nazwisko = WybranyKlient.Nazwisko;
                            Imie = WybranyKlient.Imie;
                        },
                        null);
                return zaladujFormularzKlient;
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
            
        }
        private bool SprawdzFormularz() // TODO: ZROBIENIE WALIDACJI DLA EDYCJI ODDZIALU
        {
            bool wynik = true;
            //if (Adres == null || NrTelefonu == null || Nazwa == null)
            //    wynik = false;
            //if (Adres == "" || NrTelefonu == "" || Nazwa == "")
            //    wynik = false;

            AddEnabled = wynik;
            EditEnabled = wynik;
            return wynik;
        }

        private void StworzKolekcje()
        {
            WynajmySamochodyKlienci.Clear();
            foreach (var w in Wynajmy)
            {
                string marka = "", modelA = "";
                string nazwisko = "", imie = "";
                foreach (var s in Samochody)
                {
                    if (w.IdAuto == s.IdAuto)
                    {
                        marka = s.Marka;
                        modelA = s.ModelAuta;
                    }
                }

                foreach (var k in Klienci)
                {
                    if (w.IdKlient == k.IdKlient)
                    {
                        nazwisko = k.Nazwisko;
                        imie = k.Imie;
                    }
                }

                var x = new WynajemSamochodKlient(w.IdWynajem, w.DataWypozyczenia, w.DataZwrotu, w.CalkowityKoszt, w.IdAuto, w.IdKlient, w.IdPracownik, marka, modelA, nazwisko, imie);
                WynajmySamochodyKlienci.Add(x);
            }
        }

    }
}

using System;

namespace WypozyczalaniaProjekt.ViewModel
{
    using BaseClassess;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;
    class KlienciViewModel : ViewModelBase
    {

        #region Składowe prywatne

        private Model model = null;
        private Klient wybranyKlient { get; set; }

        private int idWybranegoKlienta;
        private int? idKlient, idKarty;
        private string imie, nazwisko, plec, dataUrodzenia, pesel, nrTelefonu, adres, email, nrPrawaJazdy;

        #endregion

        #region Konstruktory

        public KlienciViewModel(Model model)
        {
            Klienci = new ObservableCollection<Klient>();
            this.model = model;
            Klienci = model.Klienci;
            IdWybranegoKlienta = -1;
        }

        #endregion

        #region Właściwości

        public ObservableCollection<Klient> Klienci { get; set; }

        public Klient WybranyKlient
        {
            get => wybranyKlient;
            set
            {
                wybranyKlient = value;
                onPropertyChanged(nameof(WybranyKlient));
                ZaladujFormularz();
            }
        }

        public int IdWybranegoKlienta
        {
            get => idWybranegoKlienta;
            set
            {
                idWybranegoKlienta = value;
                onPropertyChanged(nameof(IdWybranegoKlienta));
            }
        }

        public int? IdKlient
        {
            get => idKlient;
            set
            {
                idKlient = value;
                onPropertyChanged(nameof(IdKlient));
            }
        }
        public string Imie
        {
            get => imie;
            set
            {
                imie = value;
                onPropertyChanged(nameof(Imie));
            }
        }

        public string Plec
        {
            get => plec;
            set
            {
                plec = value;
                onPropertyChanged(nameof(Plec));
            }
        }

        public string NrTelefonu
        {
            get => nrTelefonu;
            set
            {
                nrTelefonu = value;
                onPropertyChanged(nameof(NrTelefonu));
            }
        }

        public string DataUrodzenia
        {
            get => dataUrodzenia;
            set
            {
                dataUrodzenia = value;
                onPropertyChanged(nameof(DataUrodzenia));
            }
        }
        public string Pesel
        {
            get => pesel;
            set
            {
                pesel = value;
                onPropertyChanged(nameof(Pesel));
            }
        }
        public string Nazwisko
        {
            get => nazwisko;
            set
            {
                nazwisko = value;
                onPropertyChanged(nameof(Nazwisko));
            }
        }
        public string Adres
        {
            get => adres;
            set
            {
                adres = value;
                onPropertyChanged(nameof(Adres));
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                onPropertyChanged(nameof(Email));
            }
        }

        public string NrPrawaJazdy
        {
            get => nrPrawaJazdy;
            set
            {
                nrPrawaJazdy = value;
                onPropertyChanged(nameof(NrPrawaJazdy));
            }
        }

        public int? IdKarty
        {
            get => idKarty;
            set
            {
                idKarty = value;
                onPropertyChanged(nameof(IdKarty));
            }
        }

        #endregion

        #region Polecenia

        private ICommand dodajKlienta = null;
        public ICommand DodajKlienta
        {
            get
            {
                if (dodajKlienta == null)
                    dodajKlienta = new RelayCommand(
                        arg =>
                        {
                            // TODO: KlienciVM - Dodawanie Klienta
                        },
                        null);
                return dodajKlienta;
            }
        }

        private ICommand edytujKlienta = null;
        public ICommand EdytujKlienta
        {
            get
            {
                if (edytujKlienta == null)
                    edytujKlienta = new RelayCommand(
                        arg =>
                        {
                            // TODO: KlienciVM - Edycja Klienta
                        },
                        null);
                return edytujKlienta;
            }
        }

        private ICommand usunKlienta = null;
        public ICommand UsunKlienta
        {
            get
            {
                if (usunKlienta == null)
                    usunKlienta = new RelayCommand(
                        arg =>
                        {
                            // TODO: KlienciVM - Usuwanie Klienta
                        },
                        null);
                return usunKlienta;
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

        private void ZaladujFormularz()
        {
            if (IdWybranegoKlienta > -1)
            {
                Imie = WybranyKlient.Imie;
                Nazwisko = WybranyKlient.Nazwisko;
                Plec = WybranyKlient.Plec;
                DataUrodzenia = "Jakaś data";               // TODO: KlienciVM - Naprawić datę
                Pesel = WybranyKlient.Pesel;
                NrTelefonu = WybranyKlient.NrTelefonu;
                Adres = WybranyKlient.Adres;
                Email = WybranyKlient.Email;
                NrPrawaJazdy = WybranyKlient.NrPrawaJazdy;
                IdKlient = (int)WybranyKlient.IdKlient;
                IdKarty = (int)WybranyKlient.IdKarty;
            }
            else
            {
                CzyscFormularz();
            }
        }

        private void CzyscFormularz()
        {
            Imie = "";
            Nazwisko = "";
            Plec = "";
            DataUrodzenia = "";
            Pesel = "";
            NrTelefonu = "";
            Adres = "";
            Email = "";
            NrPrawaJazdy = "";
            IdKlient = null;
            IdKarty = null;
        }
    }
}

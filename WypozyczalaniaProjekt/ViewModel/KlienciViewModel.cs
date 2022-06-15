using System;

namespace WypozyczalaniaProjekt.ViewModel
{
    using BaseClassess;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;
    class KlienciViewModel : ViewModelBase
    {

        #region Składowe prywatne

        private Model model = null;

        private int idWybranegoKlienta;
        private int? idKarty;
        private string imie, nazwisko, plec, dataUrodzenia, pesel, nrTelefonu, adres, email, nrPrawaJazdy;

        #endregion

        #region Konstruktory

        public KlienciViewModel(Model model)
        {
            Klienci = new ObservableCollection<Klient>();
            this.model = model;
            Klienci = model.Klienci;
            idWybranegoKlienta = -1;
        }

        #endregion

        #region Właściwości

        public ObservableCollection<Klient> Klienci { get; set; }

        private Klient wybranyKlient;
        public Klient WybranyKlient
        {
            get => wybranyKlient;
            set
            {
                wybranyKlient = value;
                if (wybranyKlient != null)
                {
                    DeleteEnabled = true;
                }
                else
                {
                    DeleteEnabled = false;
                }
                onPropertyChanged(nameof(WybranyKlient));
            }
        }

        public int IdWybranegoKlienta
        {
            get => idWybranegoKlienta;
            set
            {
                idWybranegoKlienta = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(IdWybranegoKlienta));
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

        public string Plec
        {
            get => plec;
            set
            {
                plec = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Plec));
            }
        }

        public string NrTelefonu
        {
            get => nrTelefonu;
            set
            {
                nrTelefonu = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(NrTelefonu));
            }
        }

        public string DataUrodzenia
        {
            get => dataUrodzenia;
            set
            {
                dataUrodzenia = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(DataUrodzenia));
            }
        }
        public string Pesel
        {
            get => pesel;
            set
            {
                pesel = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Pesel));
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
        public string Adres
        {
            get => adres;
            set
            {
                adres = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Adres));
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Email));
            }
        }

        public string NrPrawaJazdy
        {
            get => nrPrawaJazdy;
            set
            {
                nrPrawaJazdy = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(NrPrawaJazdy));
            }
        }

        public int? IdKarty
        {
            get => idKarty;
            set
            {
                idKarty = value;
                SprawdzFormularz();
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
                            var klient = new Klient(Imie, Nazwisko, Plec, Email, NrTelefonu, Adres, Pesel, NrPrawaJazdy, DateTime.Parse(DataUrodzenia), (sbyte)IdKarty);
                            if (model.DodajKlientaDoBazy(klient))
                            {
                                CzyscFormularz();
                                MessageBox.Show("Klient został dodany!");
                            }
                        },
                        arg => SprawdzFormularz());
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
                            model.EdytujKlientaWBazie(new Klient(Imie, Nazwisko, Plec, Email, NrTelefonu, Adres, Pesel, NrPrawaJazdy, DateTime.Parse(DataUrodzenia), (sbyte)IdKarty), (sbyte)WybranyKlient.IdKlient);
                            IdWybranegoKlienta = -1;
                        },
                        arg => IdWybranegoKlienta > -1);
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
                            model.UsunKlientaZBazy((sbyte)WybranyKlient.IdKlient);
                            IdWybranegoKlienta= -1;
                        },
                        arg => IdWybranegoKlienta > -1);
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


        private ICommand zaladujFormularz = null;
        public ICommand ZaladujFormularz
        {
            get
            {
                if (zaladujFormularz == null)
                    zaladujFormularz = new RelayCommand(
                        o =>
                        {
                            if (IdWybranegoKlienta > -1)
                            {
                                Imie = WybranyKlient.Imie;
                                Nazwisko = WybranyKlient.Nazwisko;
                                Plec = WybranyKlient.Plec;
                                DataUrodzenia = WybranyKlient.DataUrodzenia.ToString("yyyy-MM-dd");
                                Pesel = WybranyKlient.Pesel;
                                NrTelefonu = WybranyKlient.NrTelefonu;
                                Adres = WybranyKlient.Adres;
                                Email = WybranyKlient.Email;
                                NrPrawaJazdy = WybranyKlient.NrPrawaJazdy;
                                IdKarty = (int)WybranyKlient.IdKarty;
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
            Imie = "";
            Nazwisko = "";
            Plec = "";
            DataUrodzenia = "";
            Pesel = "";
            NrTelefonu = "";
            Adres = "";
            Email = "";
            NrPrawaJazdy = "";
            IdKarty = null;
            WybranyKlient = null;
        }

        private bool SprawdzFormularz()
        {
            bool wynik = true;

            if (IdKarty == null)
                wynik = false;
            if (Imie == "" || Nazwisko == "" || Plec == "" || DataUrodzenia == "" ||
                Pesel == "" || NrTelefonu == "" || Adres == "" || Email == "" || NrPrawaJazdy == "")
                wynik = false;

            AddEnabled = wynik;
            EditEnabled = wynik;
            return wynik;
        }
    }
}

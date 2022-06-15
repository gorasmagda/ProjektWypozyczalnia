using System;

namespace WypozyczalaniaProjekt.ViewModel
{
    using BaseClassess;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;
    class PracownicyViewModel : ViewModelBase
    {

        #region Składowe prywatne

        private Model model = null;

        private int idWybranegoPracownika;
        private decimal? pensja;
        private string imie, nazwisko, plec, nrTelefonu, dataUrodzenia, adres, email, nrPrawaJazdy, pesel;
        private Oddzial wybranyOddzial;

        #endregion

        #region Konstruktory

        public PracownicyViewModel(Model model)
        {
            Pracownicy = new ObservableCollection<Pracownik>();
            Oddzialy = new ObservableCollection<Oddzial>();
            this.model = model;
            Pracownicy = model.Pracownicy;
            Oddzialy = model.Oddzialy;
            idWybranegoPracownika = -1;
        }

        #endregion

        #region Właściwości

        public ObservableCollection<Pracownik> Pracownicy { get; set; }
        public ObservableCollection<Oddzial> Oddzialy { get; set; }

        private Pracownik wybranyPracownik;
        public Pracownik WybranyPracownik
        {
            get => wybranyPracownik;
            set
            {
                wybranyPracownik = value;
                if (wybranyPracownik != null)
                {
                    DeleteEnabled = true;
                }
                else
                {
                    DeleteEnabled = false;
                }
                onPropertyChanged(nameof(WybranyPracownik));
            }
        }
        
        
        public int IdWybranegoPracownika
        {
            get => idWybranegoPracownika;
            set
            {
                idWybranegoPracownika = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(IdWybranegoPracownika));
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

        public decimal? Pensja
        {
            get => pensja;
            set
            {
                pensja = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(Pensja));
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

        #endregion

        #region Polecenia

        private ICommand dodajPracownika = null;
        public ICommand DodajPracownika
        {
            get
            {
                if (dodajPracownika == null)
                    dodajPracownika = new RelayCommand(
                        arg =>
                        {
                            var pracownik = new Pracownik(Imie, Nazwisko, Plec, Email,NrTelefonu, Adres, Pesel, NrPrawaJazdy, DateTime.Parse(DataUrodzenia), (sbyte)WybranyOddzial.IdOddzialu, (decimal)Pensja);
                            if (model.DodajPracownikaDoBazy(pracownik))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Pracownik został dodany!");
                            }
                        },
                        arg => SprawdzFormularz());
                return dodajPracownika;
            }
        }

        private ICommand edytujPracownika = null;
        public ICommand EdytujPracownika
        {
            get
            {
                if (edytujPracownika == null)
                    edytujPracownika = new RelayCommand(
                        arg =>
                        {
                            model.EdytujPracownikaWBazie(new Pracownik(Imie, Nazwisko, Plec, Email, NrTelefonu, Adres, Pesel, NrPrawaJazdy, DateTime.Parse(DataUrodzenia), (sbyte)WybranyOddzial.IdOddzialu, (decimal)Pensja), (sbyte)WybranyPracownik.IdPracownik);
                            IdWybranegoPracownika = -1;
                        },
                        arg => IdWybranegoPracownika > -1);
                return edytujPracownika;
            }
        }

        private ICommand usunPracownika = null;

        public ICommand UsunPracownika
        {
            get
            {
                if (usunPracownika == null)
                    usunPracownika = new RelayCommand(
                        arg =>
                        {
                            model.UsunPracownikaZBazy((sbyte)WybranyPracownik.IdPracownik);
                            IdWybranegoPracownika = -1;
                        },
                        arg => IdWybranegoPracownika > -1);
                return usunPracownika;
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
                            if (IdWybranegoPracownika > -1)
                            {
                                Imie = WybranyPracownik.Imie;
                                Nazwisko = WybranyPracownik.Nazwisko;
                                Plec = WybranyPracownik.Plec;
                                NrTelefonu = WybranyPracownik.NrTelefonu;
                                DataUrodzenia = WybranyPracownik.DataUrodzenia.ToString("yyyy-MM-dd");
                                Adres = WybranyPracownik.Adres;
                                Email = WybranyPracownik.Email;
                                NrPrawaJazdy = WybranyPracownik.NrPrawaJazdy;
                                Pesel = WybranyPracownik.Pesel;
                                Pensja = WybranyPracownik.Pensja;
                                foreach (var oddzial in Oddzialy)
                                {
                                    if (oddzial.IdOddzialu == (int)WybranyPracownik.IdOddzial)
                                    {
                                        WybranyOddzial = oddzial;
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
            NrTelefonu = "";
            DataUrodzenia = "";
            Adres = "";
            Email = "";
            NrPrawaJazdy = "";
            Pesel = "";
            WybranyOddzial = null;
            Pensja = null;
            WybranyPracownik = null;
        }

        private bool SprawdzFormularz()
        {
            bool wynik = true;

            if (WybranyOddzial == null || Pensja == null)
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

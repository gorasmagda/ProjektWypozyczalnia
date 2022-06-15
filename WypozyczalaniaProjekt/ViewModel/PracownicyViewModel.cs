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
        private int? idOddzial;
        private decimal? pensja;
        private string imie, nazwisko, plec, nrTelefonu, dataUrodzenia, adres, email, nrPrawaJazdy, pesel;

        #endregion

        #region Konstruktory

        public PracownicyViewModel(Model model)
        {
            Pracownicy = new ObservableCollection<Pracownik>();
            this.model = model;
            Pracownicy = model.Pracownicy;
            idWybranegoPracownika = -1;
        }

        #endregion

        #region Właściwości

        public ObservableCollection<Pracownik> Pracownicy { get; set; }
        public ObservableCollection<Oddzial> Oddzialy { get; set; }
        public Pracownik WybranyPracownik { get; set; }
        public Oddzial WybranyOddzial { get; set; }
        
        
        public int IdWybranegoPracownika
        {
            get => idWybranegoPracownika;
            set
            {
                idWybranegoPracownika = value;
                onPropertyChanged(nameof(IdWybranegoPracownika));
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

        public decimal? Pensja
        {
            get => pensja;
            set
            {
                pensja = value;
                onPropertyChanged(nameof(Pensja));
            }
        }

        public int? IdOddzial
        {
            get => idOddzial;
            set
            {
                idOddzial = value;
                onPropertyChanged(nameof(IdOddzial));
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
                                IdOddzial = (int)WybranyPracownik.IdOddzial;
                                Pensja = WybranyPracownik.Pensja;
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
            IdOddzial = null;
            Pensja = null;
        }

        private bool SprawdzFormularz()
        {
            bool wynik = true;

            if (IdOddzial == null || Pensja == null)
                wynik = false;
            if (Imie == "" || Nazwisko == "" || Plec == "" || DataUrodzenia == "" ||
                Pesel == "" || NrTelefonu == "" || Adres == "" || Email == "" || NrPrawaJazdy == "")
                wynik = false;

            return wynik;
        }
    }
}

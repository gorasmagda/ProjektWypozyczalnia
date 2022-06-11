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
        #endregion
        public ObservableCollection<Pracownik> Pracownicy { get; set; }
        public PracownicyViewModel(Model model)
        {
            NrPrawaJazdy = "63534";
            Pracownicy = new ObservableCollection<Pracownik>();
            this.model = model;
            Pracownicy = model.Pracownicy;

        }

        private string wybranyPracownik;
        public string WybranyPracownik
        {
            get => wybranyPracownik;
            set
            {
                wybranyPracownik = value;
                onPropertyChanged(nameof(WybranyPracownik));
                Console.WriteLine("Wybrany pracownik to madzia");

            }
        }

        private int idPracownik;
        public int IdPracownik
        {
            get => idPracownik;
            set
            {
                idPracownik = value;
                onPropertyChanged(nameof(IdPracownik));
            }
        }

        private string imie;
        public string Imie
        {
            get => imie;
            set
            {
                imie = value;
                onPropertyChanged(nameof(Imie));
            }
        }

        private string plec;
        public string Plec
        {
            get => plec;
            set
            {
                plec = value;
                onPropertyChanged(nameof(Plec));
            }
        }

        private string nrTelefonu;
        public string NrTelefonu
        {
            get => nrTelefonu;
            set
            {
                nrTelefonu = value;
                onPropertyChanged(nameof(NrTelefonu));
            }
        }

        private string dataUrodzenia;
        public string DataUrodzenia
        {
            get => dataUrodzenia;
            set
            {
                dataUrodzenia = value;
                onPropertyChanged(nameof(DataUrodzenia));
            }
        }

        private decimal pensja;
        public decimal Pensja
        {
            get => pensja;
            set
            {
                pensja = value;
                onPropertyChanged(nameof(Pensja));
            }
        }

        private int idOddzial;
        public int IdOddzial
        {
            get => idOddzial;
            set
            {
                idOddzial = value;
                onPropertyChanged(nameof(IdOddzial));
            }
        }

        private string pesel;
        public string Pesel
        {
            get => pesel;
            set
            {
                pesel = value;
                onPropertyChanged(nameof(Pesel));
            }
        }

        private string nazwisko;
        public string Nazwisko
        {
            get => nazwisko;
            set
            {
                nazwisko = value;
                onPropertyChanged(nameof(Nazwisko));
            }
        }

        private string adres;
        public string Adres
        {
            get => adres;
            set
            {
                adres = value;
                onPropertyChanged(nameof(Adres));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                onPropertyChanged(nameof(Email));
            }
        }

        private string nrPrawaJazdy;
        public string NrPrawaJazdy
        {
            get => nrPrawaJazdy;
            set
            {
                nrPrawaJazdy = value;
                onPropertyChanged(nameof(NrPrawaJazdy));
            }
        }


        private ICommand edytujPClick = null;

        public ICommand EdytujPClick
        {
            get
            {
                if (edytujPClick == null)
                    edytujPClick = new RelayCommand(
                    arg =>
                    {
                        //NrPrawaJazdy = "000000";
                    }

                   , null);



                return edytujPClick;
            }

        }

        private ICommand dodajPClick = null;

        public ICommand DodajPClick
        {
            get
            {
                if (dodajPClick == null)
                    dodajPClick = new RelayCommand(
                    arg =>
                    {

                    }

                   , null);



                return dodajPClick;
            }

        }


        private ICommand usunPClick = null;

        public ICommand UsunPClick
        {
            get
            {
                if (usunPClick == null)
                    usunPClick = new RelayCommand(
                    arg =>
                    {
                        Pesel = "87654";
                    }

                   , null);



                return usunPClick;
            }

        }

    }
}

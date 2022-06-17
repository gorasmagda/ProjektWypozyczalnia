using System;

namespace WypozyczalaniaProjekt.ViewModel
{
    using BaseClassess;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;

    class LogInViewModel : ViewModelBase
    {
        #region Składowe prywatne

        private Model model = null;

        #endregion

        #region Konstruktory

        public LogInViewModel(Model model)
        {
            Pracownicy = new ObservableCollection<Pracownik>();
            this.model = model;
            Pracownicy = model.Pracownicy;
        }

        public LogInViewModel(){ } //Czemu bez tego widok nie działa?

        public ObservableCollection<Pracownik> Pracownicy { get; set; }

        #endregion

        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                onPropertyChanged(nameof(Login));
            }
        }

        private string haslo;
        public string Haslo
        {
            get => haslo;
            set
            {
                haslo = value;
                onPropertyChanged(nameof(Haslo));
            }
        }

        private ICommand wyczyscClick;
        public ICommand WyczyscClick => wyczyscClick ?? (wyczyscClick = new RelayCommand(
            o =>
            {
                Login = "";
                Haslo = "";
            },
            null));

        private ICommand zalogujClick;
        public ICommand ZalogujClick => zalogujClick ?? (zalogujClick = new RelayCommand(
            o =>
            {
                if (CzyJestKtosTakiJestWBazie())
                {
                    Console.WriteLine("Udalo sie");
                }
                else
                {
                    MessageBox.Show("Niepoprawny login lub hasło!");
                }
            },
            o => Login != null && Haslo != null && Login != "" && Haslo != ""));

        public bool CzyJestKtosTakiJestWBazie()
        {
            bool wynik = false;

            foreach (var l in model.Pracownicy)
            {
                if (Login == l.Email && Haslo == l.Pesel)
                {
                    wynik = true;
                }
            }
            return wynik;
        }
    }
}
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
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;

    class LogowanieViewModel : ViewModelBase
    {

        #region Składowe prywatne

        private Model model = null;

        #endregion

        #region Konstruktory

        public LogowanieViewModel(Model model)
        {
            Pracownicy = new ObservableCollection<Pracownik>();
            this.model = model;
            Pracownicy = model.Pracownicy;
            WidocznoscZakladekAdmina = "Collapsed";
            WidocznoscZakladekPracownika = "Collapsed";
            WidocznoscWyloguj = "Collapsed";

            WidocznoscZakladekAdmina = "Visible";
            WidocznoscZakladekPracownika = "Visible";
            WidocznoscWyloguj = "Visible";


            Login = "M.Wysocki@wp.pl";
            Haslo = "89080128211";
        }

        #endregion

        public ObservableCollection<Pracownik> Pracownicy { get; set; }

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

        private string widocznoscZakladekAdmina;
        public string WidocznoscZakladekAdmina
        {
            get => widocznoscZakladekAdmina;
            set
            {
                widocznoscZakladekAdmina = value;
                onPropertyChanged(nameof(WidocznoscZakladekAdmina));
            }
        }

        private string widocznoscZakladekPracownika;
        public string WidocznoscZakladekPracownika
        {
            get => widocznoscZakladekPracownika;
            set
            {
                widocznoscZakladekPracownika = value;
                onPropertyChanged(nameof(WidocznoscZakladekPracownika));
            }
        }

        private string widocznoscWyloguj;
        public string WidocznoscWyloguj
        {
            get => widocznoscWyloguj;
            set
            {
                widocznoscWyloguj = value;
                onPropertyChanged(nameof(WidocznoscWyloguj));
            }
        }

        private bool oddzialyPokazane;
        public bool OddzialyPokazane
        {
            get => oddzialyPokazane;
            set
            {
                oddzialyPokazane = value;
                onPropertyChanged(nameof(OddzialyPokazane));
            }
        }

        private bool samochodyPokazane;
        public bool SamochodyPokazane
        {
            get => samochodyPokazane;
            set
            {
                samochodyPokazane = value;
                onPropertyChanged(nameof(SamochodyPokazane));
            }
        }
        
        private bool logowaniePokazane;
        public bool LogowaniePokazane
        {
            get => logowaniePokazane;
            set
            {
                logowaniePokazane = value;
                onPropertyChanged(nameof(LogowaniePokazane));
            }
        }

        private ICommand wyczysc;
        public ICommand Wyczysc => wyczysc ?? (wyczysc = new RelayCommand(
            o =>
            {
                Login = "";
                Haslo = "";
            },
            null));

        private ICommand zaloguj;
        public ICommand Zaloguj => zaloguj ?? (zaloguj = new RelayCommand(
            o =>
            {
                WidocznoscZakladekAdmina = "Collapsed";
                WidocznoscZakladekPracownika = "Collapsed";
                if (CzyJestKtosTakiJestWBazie())
                {
                    Console.WriteLine("Udalo sie");
                    if (Login == Properties.Settings.Default.LoginAdmin && Haslo == Properties.Settings.Default.HasloAdmin)
                    {
                        WidocznoscZakladekAdmina = "Visible";
                        WidocznoscZakladekPracownika = "Visible";
                        WidocznoscWyloguj = "Visible";
                        OddzialyPokazane = true;
                        model.Uzytkownik = "Admin";
                        model.NazwiskoZalogowanegoPracownika = "Wysocki";
                    }
                    else
                    {
                        WidocznoscZakladekPracownika = "Visible";
                        WidocznoscWyloguj = "Visible";
                        SamochodyPokazane = true;
                        model.Uzytkownik = "User";
                        foreach (var p in model.Pracownicy)
                        {
                            if (Login == p.Email)
                            {
                                model.NazwiskoZalogowanegoPracownika = p.Nazwisko;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Niepoprawny login lub hasło!");
                }
            },
            o => Login != null && Haslo != null && Login != "" && Haslo != ""));

        private ICommand wyloguj;
        public ICommand Wyloguj => wyloguj ?? (wyloguj = new RelayCommand(
            o =>
            {
                Login = "";
                Haslo = "";
                WidocznoscZakladekAdmina = "Collapsed";
                WidocznoscZakladekPracownika = "Collapsed";
                WidocznoscWyloguj = "Collapsed";
                LogowaniePokazane = true;
                OddzialyPokazane = false;
                SamochodyPokazane = false;
            },
            null));

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

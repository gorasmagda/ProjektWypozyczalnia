using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.ViewModel
{
    using BaseClassess;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    class KlienciViewModel : ViewModelBase
    {

        public ObservableCollection<string> ListaKlientow { get; set; }

        public KlienciViewModel()
        {
            IdKlient= 2;
            ListaKlientow= new ObservableCollection<string>();
            ListaKlientow.Add("Klient");
        }

        private string wybranyKlient;
        public string WybranyKlient
        {
            get => wybranyKlient;
            set
            {
                wybranyKlient= value;
                onPropertyChanged(nameof(WybranyKlient));
                Console.WriteLine("Wybrane klient to madzia");

            }
        }


        private int idKlient;
        public int IdKlient
        {
            get => idKlient;
            set
            {
                idKlient = value;
                onPropertyChanged(nameof(IdKlient));
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

        private int idKarty;
        public int IdKarty
        {
            get => idKarty;
            set
            {
                idKarty = value;
                onPropertyChanged(nameof(IdKarty));
            }
        }

        private ICommand edytujKClick = null;

        public ICommand EdytujKClick
        {
            get
            {
                if (edytujKClick == null)
                    edytujKClick = new RelayCommand(
                    arg =>
                    {
                        Pesel = "1234";
                    }

                   , null);



                return edytujKClick;
            }

        }

        private ICommand dodajKClick = null;

        public ICommand DodajKClick
        {
            get
            {
                if (dodajKClick == null)
                    dodajKClick = new RelayCommand(
                    arg =>
                    {

                    }

                   , null);



                return dodajKClick;
            }

        }


        private ICommand usunKClick = null;

        public ICommand UsunKClick
        {
            get
            {
                if (usunKClick == null)
                    usunKClick = new RelayCommand(
                    arg =>
                    {
                        Pesel = "9876";
                    }

                   , null);



                return usunKClick;
            }

        }



    }
}

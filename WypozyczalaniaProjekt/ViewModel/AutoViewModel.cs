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

    class AutoViewModel : ViewModelBase
    {


        public ObservableCollection<string> Lista { get; set; }

        public AutoViewModel()
        {
            IdAuto = 10;
            Lista = new ObservableCollection<string>();
            Lista.Add("Madzia");
             
        }


        private string wybraneAuto;
        public string WybraneAuto
        {
            get => wybraneAuto;
            set
            {
                wybraneAuto = value;
                onPropertyChanged(nameof(WybraneAuto));
                Console.WriteLine("Wybrane auto to madzia");

            }
        }

        private int idAuto;
        public int IdAuto
        {
            get => idAuto;
            set
            {
                idAuto = value;
                onPropertyChanged(nameof(IdAuto));

            }
        }

        private string kaucja;
        public string Kaucja
        {
            get => kaucja;
            set
            {
                kaucja = value;
                onPropertyChanged(nameof(Kaucja));
            }
        }

        private string lokalizacja;
        public string Lokalizacja
        {
            get => lokalizacja;
            set
            {
                lokalizacja = value;
                onPropertyChanged(nameof(Lokalizacja));
            }
        }

        private string model;
        public string Model
        {
            get => model;
            set
            {
                model= value;
                onPropertyChanged(nameof(Model));
            }
        }


        private string rocznik;
        public string Rocznik
        {
            get => rocznik;
            set
            {
                rocznik = value;
                onPropertyChanged(nameof(Rocznik));
            }
        }

        private string iloscMiejsc;
        public string IloscMiejsc
        {
            get => iloscMiejsc;
            set
            {
                iloscMiejsc = value;
                onPropertyChanged(nameof(IloscMiejsc));
            }
        }

        private string przebieg;
        public string Przebieg
        {
            get => przebieg;
            set
            {
                przebieg = value;
                onPropertyChanged(nameof(Przebieg));
            }
        }

        private string nrRejestracyjny;
        public string NrRejestracyjny
        {
            get => nrRejestracyjny;
            set
            {
                nrRejestracyjny = value;
                onPropertyChanged(nameof(NrRejestracyjny));
            }
        }

        private decimal cena;
        public decimal Cena
        {
            get => cena;
            set
            {
                cena = value;
                onPropertyChanged(nameof(Cena));
            }
        }

        private string dostepnosc;
        public string Dostepnosc
        {
            get => dostepnosc;
            set
            {
                dostepnosc = value;
                onPropertyChanged(nameof(Dostepnosc));
            }
        }
        private string marka;
        public string Marka
        {
            get => marka;
            set
            {
                marka = value;
                onPropertyChanged(nameof(Marka));
            }
        }
        private string kolor;
        public string Kolor
        {
            get => kolor;
            set
            {
                kolor = value;
                onPropertyChanged(nameof(Kolor));
            }
        }

        private string skrzynia;
        public string Skrzynia
        {
            get => skrzynia;
            set
            {
                skrzynia = value;
                onPropertyChanged(nameof(Skrzynia));
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






        private ICommand edytujAClick = null;
        
        public ICommand EdytujAClick
        {
            get
            {
                if (edytujAClick == null)
                    edytujAClick = new RelayCommand(
                    arg =>
                    {
                        IdAuto=12;
                    }
                         
                   ,null);



                return edytujAClick;
            }

        }

        private ICommand dodajAClick = null;

        public ICommand DodajAClick
        {
            get
            {
                if (dodajAClick == null)
                    dodajAClick = new RelayCommand(
                    arg =>
                    {
                        
                    }

                   , null);



                return dodajAClick;
            }

        }


        private ICommand usunAClick = null;

        public ICommand UsunAClick
        {
            get
            {
                if (usunAClick == null)
                    usunAClick = new RelayCommand(
                    arg =>
                    {
                       
                    }

                   , null);



                return usunAClick;
            }

        }


        



    }
}

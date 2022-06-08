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
    using WypozyczalaniaProjekt.Model;
    using WypozyczalaniaProjekt.DAL.Encje;

    class AutoViewModel : ViewModelBase
    {

        #region Składowe prywatne
        private Model model = null;
        #endregion

        public ObservableCollection<Samochod> Samochody { get; set; }

        #region Konstruktory
        public AutoViewModel(Model model)
        {
            
            Samochody = new ObservableCollection<Samochod>();
            this.model = model;
            Samochody = model.Samochody;
            
        }
        #endregion

        public Samochod WybraneAuto { get; set; }

        private int idWybranegoAuta;
        public int IdWybranegoAuta
        {
            get { return idWybranegoAuta; }
            set
            {
                idWybranegoAuta = value;
                onPropertyChanged(nameof(IdWybranegoAuta));
            }
        }

        private int idAuto;
        public int IdAuto
        {
            get { return idAuto;  }
            set
            {
                idAuto = value;
                onPropertyChanged(nameof(IdAuto));

            }
        }

        private decimal kaucja;
        public decimal Kaucja
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

        private string modelAuta;
        public string ModelAuta
        {
            get => modelAuta;
            set
            {
                modelAuta = value;
                onPropertyChanged(nameof(Model));
            }
        }


        private int rocznik;
        public int Rocznik
        {
            get => rocznik;
            set
            {
                rocznik = value;
                onPropertyChanged(nameof(Rocznik));
            }
        }

        private int iloscMiejsc;
        public int IloscMiejsc
        {
            get => iloscMiejsc;
            set
            {
                iloscMiejsc = value;
                onPropertyChanged(nameof(IloscMiejsc));
            }
        }

        private int przebieg;
        public int Przebieg
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

        private ICommand zaladujFormularz = null;
        public ICommand ZaladujFormularz
        {
            get
            {
                if (zaladujFormularz == null)
                    zaladujFormularz = new RelayCommand
                        (o =>
                        {
                            if (IdWybranegoAuta > -1)
                            {
                                IdAuto = (int)WybraneAuto.IdAuto;
                                Marka = WybraneAuto.Marka;
                                Kaucja = WybraneAuto.Kaucja;
                                Lokalizacja = WybraneAuto.AktualnaLokalizacja;
                                ModelAuta = WybraneAuto.Model;
                                Rocznik = WybraneAuto.Rocznik;
                                IloscMiejsc = WybraneAuto.IloscMiejsc;
                                Przebieg = WybraneAuto.Przebieg;
                                NrRejestracyjny = WybraneAuto.NrRejestracyjny;
                                Cena = WybraneAuto.Cena;
                                Dostepnosc = WybraneAuto.Dostepnosc;
                                Kolor = WybraneAuto.Kolor;
                                Skrzynia = WybraneAuto.Skrzynia;
                                IdOddzial = (int)WybraneAuto.IdOddzialu;




                            }
                            else
                            {
                                
                                //TO DO przypisanie wartości do pustego formularza 
                                //np. zapytanie do sql o najwikesza wartosc ID i potem wypisanie o jeden wiekszego i przypisanie go do idauto w pustym formularzu 
                                // i jeszcze rozwiazanie do oddziału? 

                                IdAuto = (int) Samochody.Last().IdAuto + 1;
                                Marka = "";
                                Kaucja = 0;
                                Lokalizacja = "Madzia";
                                ModelAuta = "";
                                Rocznik = 0;
                                IloscMiejsc = 0;
                                Przebieg = 0;
                                NrRejestracyjny = "";
                                Cena = 0;
                                Dostepnosc = "";
                                Kolor = "";
                                Skrzynia = "";
                                //IdOddzial = 0;
                            }

                        }
                        ,
                        o => true
                        );
                return zaladujFormularz;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalaniaProjekt.ViewModel.BaseClassess;

namespace WypozyczalaniaProjekt.ViewModel
{
    using BaseClassess;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;
    
    class OddzialViewModel : ViewModelBase
    {
        #region Składowe prywatne

        private Model model = null;
        private int idWybranegoOddzialu;
        private string adres, nrTelefonu, nazwa;

        #endregion

        #region Konstruktory

        public OddzialViewModel(Model model)
        {
            this.model = model;
            Oddzialy = new ObservableCollection<Oddzial>();
            Oddzialy = model.Oddzialy;
            idWybranegoOddzialu = -1;
        }
        #endregion

        #region Właściwości

        public ObservableCollection<Oddzial> Oddzialy { get; set; }
        public Oddzial WybranyOddzial { get; set; }
        public int IdWybranegoOddzialu
        {
            get => idWybranegoOddzialu;
            set
            {
                idWybranegoOddzialu = value;
                onPropertyChanged(nameof(IdWybranegoOddzialu));
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
        public string NrTelefonu
        {
            get => nrTelefonu;
            set
            {
                nrTelefonu = value;
                onPropertyChanged(nameof(NrTelefonu));
            }
        }
        public string Nazwa
        {
            get => nazwa;
            set
            {
                nazwa = value;
                onPropertyChanged(nameof(Nazwa));
            }
        }

        #endregion

        #region Polecenia

        private ICommand dodajOddzial = null;
        public ICommand DodajOddzial
        {
            get
            {
                if(dodajOddzial == null)
                    dodajOddzial = new RelayCommand(
                        arg =>
                        {
                            var oddzial = new Oddzial(Adres, NrTelefonu, Nazwa);
                            if(model.DodajOddzialDoBazy(oddzial))
                            {
                                CzyscFormularz();
                                MessageBox.Show("Oddział został dodany!");
                            }
                        },
                        arg => SprawdzFormularz());
                return dodajOddzial;
            }
        }

        private ICommand edytujOddzial = null;
        public ICommand EdytujOddzial
        {
            get
            {
                if (edytujOddzial == null)
                    edytujOddzial = new RelayCommand(
                        arg =>
                        {
                            model.EdytujOddzialWBazie(new Oddzial(Adres, NrTelefonu, Nazwa), (sbyte)WybranyOddzial.IdOddzialu);
                            IdWybranegoOddzialu = -1;
                        },
                        arg => IdWybranegoOddzialu > -1);
                return edytujOddzial;
            }
        }

        private ICommand usunOddzial = null;
        public ICommand UsunOddzial
        {
            get
            {
                if (usunOddzial == null)
                    usunOddzial = new RelayCommand(
                        arg =>
                        {
                            model.UsunOddzialZBazy((sbyte)WybranyOddzial.IdOddzialu);
                            IdWybranegoOddzialu = -1;
                        },
                        arg => IdWybranegoOddzialu > -1);
                return usunOddzial;
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
                            if (IdWybranegoOddzialu > -1)
                            {
                                Adres = WybranyOddzial.Adres;
                                NrTelefonu = WybranyOddzial.NrTelefonu;
                                Nazwa = WybranyOddzial.Nazwa;
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

        private void CzyscFormularz()
        {
            Adres = "";
            NrTelefonu = "";
            Nazwa = "";
        }
        private bool SprawdzFormularz()
        {
            bool wynik = true;
            if (Adres == null || NrTelefonu == null || Nazwa == null)
                wynik = false;
            if (Adres == "" || NrTelefonu == "" || Nazwa == "")
                wynik = false;
            return wynik;
        }

        #endregion
    }
}

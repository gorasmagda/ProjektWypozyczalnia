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
    using WypozyczalaniaProjekt.DAL.Encje;
    using WypozyczalaniaProjekt.Model;

    class WynajemViewModel : ViewModelBase
    {

        #region Składowe prywatne

        private Model model = null;
        private int idWybranegoWynajmu;
        private string adres;
        private DateTime dataRozpoczecia, dataZakonczenia;

        #endregion

        #region Konstruktory

        public WynajemViewModel(Model model)
        {
            this.model = model;
            Wynajmy = new ObservableCollection<Wynajem>();
            //Wynajmy = model.Wynajmy;
            IdWybranegoWynajmu = -1;
        }
        #endregion

        #region Właściwości

        public ObservableCollection<Wynajem> Wynajmy { get; set; }

        private Wynajem wybranyWynajem;
        public Wynajem WybranyWynajem
        {
            get => wybranyWynajem;
            set
            {
                wybranyWynajem = value;
                if (wybranyWynajem != null)
                {
                    DeleteEnabled = true;
                }
                else
                {
                    DeleteEnabled = false;
                }
                onPropertyChanged(nameof(WybranyWynajem));
            }
        }
        public int IdWybranegoWynajmu
        {
            get => idWybranegoWynajmu;
            set
            {
                idWybranegoWynajmu = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(IdWybranegoWynajmu));
            }
        }

        public DateTime DataRozpoczecia
        {
            get => dataRozpoczecia;
            set
            {
                dataRozpoczecia = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(DataRozpoczecia));
            }
        }

        public DateTime DataZakonczenia
        {
            get => dataZakonczenia;
            set
            {
                dataZakonczenia = value;
                SprawdzFormularz();
                onPropertyChanged(nameof(DataZakonczenia));
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

        #endregion

        #region Polecenia

        private ICommand dodajWynajem = null;
        public ICommand DodajWynajem
        {
            get
            {
                if (dodajWynajem == null)
                    dodajWynajem = new RelayCommand(
                        arg =>
                        {
                            //var oddzial = new Oddzial(Adres, NrTelefonu, Nazwa);
                            //if (model.DodajOddzialDoBazy(oddzial))
                            //{
                            //    CzyscFormularz();
                            //    WybranyOddzial = null;
                            //    MessageBox.Show("Oddział został dodany!");
                            //}
                        },
                        arg => SprawdzFormularz());
                return dodajWynajem;
            }
        }

        private ICommand edytujWynajem = null;
        public ICommand EdytujWynajem
        {
            get
            {
                if (edytujWynajem == null)
                    edytujWynajem = new RelayCommand(
                        arg =>
                        {
                            //model.EdytujOddzialWBazie(new Oddzial(Adres, NrTelefonu, Nazwa), (sbyte)WybranyOddzial.IdOddzialu);
                            //CzyscFormularz();
                            //WybranyOddzial = null;
                        },
                        arg => IdWybranegoWynajmu > -1);
                return edytujWynajem;
            }
        }

        private ICommand usunWynajem = null;
        public ICommand UsunWynajem
        {
            get
            {
                if (usunWynajem == null)
                    usunWynajem = new RelayCommand(
                        arg =>
                        {
                            //model.UsunOddzialZBazy((sbyte)WybranyOddzial.IdOddzialu);
                            //IdWybranegoOddzialu = -1;
                        },
                        arg => IdWybranegoWynajmu > -1);
                return usunWynajem;
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
                            if (IdWybranegoWynajmu > -1)
                            {
                                //Adres = WybranyOddzial.Adres;
                                //NrTelefonu = WybranyOddzial.NrTelefonu;
                                //Nazwa = WybranyOddzial.Nazwa;
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
            
        }
        private bool SprawdzFormularz() // TODO: ZROBIENIE WALIDACJI DLA EDYCJI ODDZIALU
        {
            bool wynik = true;
            //if (Adres == null || NrTelefonu == null || Nazwa == null)
            //    wynik = false;
            //if (Adres == "" || NrTelefonu == "" || Nazwa == "")
            //    wynik = false;

            AddEnabled = wynik;
            EditEnabled = wynik;
            return wynik;
        }

    }
}

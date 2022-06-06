using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.ViewModel
{
    class MainViewModel
    {

        //stworzenie instancji modelu
       

        public AutoViewModel AutoVM { get; set; }
        public PracownicyViewModel PracownicyVM { get; set; }
        public KlienciViewModel KlienciVM { get; set; }
        

        public MainViewModel()
        {
            //stworzenie viemodeli pomocniczych - dla każdej karty
            //przekazanie referencji do instancji modelu tak
            //aby wszystkie obiekty modeli widoków pracowały na tym samym modelu
            AutoVM = new AutoViewModel();
            PracownicyVM = new PracownicyViewModel();
            KlienciVM = new KlienciViewModel();


        }
    }
}

namespace WypozyczalaniaProjekt.ViewModel
{

    using WypozyczalaniaProjekt.Model;

    class MainViewModel
    {

        //stworzenie instancji modelu

        private Model model = new Model();

        public AutoViewModel AutoVM { get; set; }
        public PracownicyViewModel PracownicyVM { get; set; }
        public KlienciViewModel KlienciVM { get; set; }
        public OddzialViewModel OddzialVM { get; set; }
        public WynajemViewModel WynajemVM { get; set; }

        public MainViewModel()
        {
            //stworzenie viemodeli pomocniczych - dla każdej karty
            //przekazanie referencji do instancji modelu tak
            //aby wszystkie obiekty modeli widoków pracowały na tym samym modelu
            AutoVM = new AutoViewModel(model);
            PracownicyVM = new PracownicyViewModel(model);
            KlienciVM = new KlienciViewModel(model);
            OddzialVM = new OddzialViewModel(model);
            WynajemVM = new WynajemViewModel(model);
        }
    }
}

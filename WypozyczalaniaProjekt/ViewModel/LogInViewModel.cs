using System;
using System.Windows.Input;
using WypozyczalaniaProjekt.ViewModel.BaseClassess;

namespace WypozyczalaniaProjekt.ViewModel
{
    class LogInViewModel : ViewModelBase
    {

        private ICommand zalogujClick;
        public ICommand ZalogujClick => zalogujClick ?? (zalogujClick = new RelayCommand(
            o =>
            {
                Console.WriteLine("Zadziało się");
            },
            null));
    }
}

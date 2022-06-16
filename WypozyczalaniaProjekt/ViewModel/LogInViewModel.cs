using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WypozyczalaniaProjekt.ViewModel.BaseClassess;

namespace WypozyczalaniaProjekt.ViewModel
{
    class LogInViewModel
    {
        private ICommand zalogujClick;

        public ICommand ZalogujClick => zalogujClick ?? (zalogujClick = new RelayCommand(
            o => Console.WriteLine("Zadziało się"), null));
    }
}

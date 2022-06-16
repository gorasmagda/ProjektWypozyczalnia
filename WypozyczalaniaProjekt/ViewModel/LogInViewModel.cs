using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WypozyczalaniaProjekt.ViewModel.BaseClassess;

namespace WypozyczalaniaProjekt.ViewModel
{
    class LogInViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand zalogujClick;

        public ICommand ZalogujClick => zalogujClick ?? (zalogujClick = new RelayCommand(
            o => 
            {
                Console.WriteLine("Zadziało się");
            }, null));
    }
}

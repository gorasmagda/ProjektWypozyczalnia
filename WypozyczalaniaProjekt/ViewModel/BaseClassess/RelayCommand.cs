using System;
using System.Windows.Input;

namespace WypozyczalaniaProjekt.ViewModel.BaseClassess
{
    class RelayCommand : ICommand
    {
        #region pola prywatne

        //referencje metod polecenia (Command) zdefinowanych w interfejsie ICommand

        //delegata Action<object> jest typem określającym metody nic nie zwarające 
        //o jednym argumencie typu object
        readonly Action<object> _execute;
        //delegata Predicate<object> oznacza metodę zwracającą zmienną typu bool o argumencie object
        readonly Predicate<object> _canExecute;

        #endregion

        #region konstruktor

        //metody składowe interfejsu ICommand zostaną przekazane do ogólnej klasy polecenia poprzez 
        //konstruktor z zewnątrz klasy polecnia.
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            else
                _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region Składowe interfejsu ICommand
        //składowe interfesu ICommand w odniesienu do wstrzykniętych z zewnątrz metod
        //referencje do których przechowujemy w prywatnych polach

        //metoda określająca czy polecenie może zostac wykonane
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        //zdarzenie informujące o możliwości wykonania polecenie
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        //metoda wykonywana przez polecenie
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }

}

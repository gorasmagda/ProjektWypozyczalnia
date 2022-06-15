using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WypozyczalaniaProjekt.View
{
    /// <summary>
    /// Logika interakcji dla klasy ButtonsUC.xaml
    /// </summary>
    public partial class ButtonsUC : UserControl
    {
        public ButtonsUC()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------
        // EVENTS
        // ----------------------------------------------------------------------------

        // ADD BUTTON CLICK
        public static readonly RoutedEvent AddClickEvent =
            EventManager.RegisterRoutedEvent(
                nameof(AddClick),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(ButtonsUC));

        public event RoutedEventHandler AddClick
        {
            add { AddHandler(AddClickEvent, value); }
            remove { RemoveHandler(AddClickEvent, value); }
        }

        public void RaiseAddClick()
        {
            RoutedEventArgs newEventArgs =
                new RoutedEventArgs(ButtonsUC.AddClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            RaiseAddClick();
        }

        // EDIT BUTTON CLICK
        public static readonly RoutedEvent EditClickEvent =
            EventManager.RegisterRoutedEvent(
                nameof(EditClick),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(ButtonsUC));

        public event RoutedEventHandler EditClick
        {
            add { AddHandler(EditClickEvent, value); }
            remove { RemoveHandler(EditClickEvent, value); }
        }

        public void RaiseEditClick()
        {
            RoutedEventArgs newEventArgs =
                new RoutedEventArgs(ButtonsUC.EditClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            RaiseEditClick();
        }

        // DELETE BUTTON CLICK
        public static readonly RoutedEvent DeleteClickEvent =
            EventManager.RegisterRoutedEvent(
                nameof(DeleteClick),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(ButtonsUC));

        public event RoutedEventHandler DeleteClick
        {
            add { AddHandler(DeleteClickEvent, value); }
            remove { RemoveHandler(DeleteClickEvent, value); }
        }

        public void RaiseDeleteClick()
        {
            RoutedEventArgs newEventArgs =
                new RoutedEventArgs(ButtonsUC.DeleteClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            RaiseDeleteClick();
        }

        // CLEAN BUTTON CLICK
        public static readonly RoutedEvent CleanClickEvent =
            EventManager.RegisterRoutedEvent(
                nameof(CleanClick),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(ButtonsUC));

        public event RoutedEventHandler CleanClick
        {
            add { AddHandler(CleanClickEvent, value); }
            remove { RemoveHandler(CleanClickEvent, value); }
        }

        public void RaiseCleanClick()
        {
            RoutedEventArgs newEventArgs =
                new RoutedEventArgs(ButtonsUC.CleanClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            RaiseCleanClick();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;

    class Model
    {

        public ObservableCollection<Samochod> Samochody { get; set; } = new ObservableCollection<Samochod>();

        public Model()
        {
            //pobranie dabych z bazy do kolekcji
            var samochody = RepozytoriumSamochody.PobierzWszystkieSamochody();
            foreach (var s in samochody)
                Samochody.Add(s);
        }

    }
}

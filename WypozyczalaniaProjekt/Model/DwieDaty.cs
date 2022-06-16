using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.Model
{
    class DwieDaty
    {
        public DwieDaty(DateTime start, DateTime end)
        {
            Start = start;
            Koniec = end;
        }

        public DateTime Start { get; set; }

        public DateTime Koniec { get; set; }

        public override string ToString()
        {
            return $"od {Start:yyyy-MM-dd} do {Koniec:yyyy-MM-dd}";
        }
    }
}

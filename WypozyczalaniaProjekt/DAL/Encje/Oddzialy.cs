using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Oddzialy
    {
        public sbyte? IdOddzialu { get; set; }
        public string Adres { get; set; }
        public string NrTelefonu { get; set; }
        public string Nazwa { get; set; }

        public Oddzialy(MySqlDataReader reader)
        {
            IdOddzialu = sbyte.Parse(reader["id_oddzialu"].ToString());
            Adres = reader["adres"].ToString();
            NrTelefonu = reader["nr_telefonu"].ToString();
            Nazwa = reader["nazwa"].ToString();
        }

        public Oddzialy(string adres, string nrtelefonu, string nazwa)
        {
            IdOddzialu = null;
            Adres = adres.Trim();
            NrTelefonu = nrtelefonu.Trim();
            Nazwa = nazwa.Trim();
        }

        public Oddzialy(Oddzialy oddzial)
        {
            IdOddzialu = oddzial.IdOddzialu;
            Adres = oddzial.Adres;
            NrTelefonu = oddzial.NrTelefonu;
            Nazwa = oddzial.Nazwa;
        }
    }

}

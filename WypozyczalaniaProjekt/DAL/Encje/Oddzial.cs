using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Oddzial
    {
        public sbyte? IdOddzialu { get; set; }
        public string Adres { get; set; }
        public string NrTelefonu { get; set; }
        public string Nazwa { get; set; }

        public Oddzial(MySqlDataReader reader)
        {
            IdOddzialu = sbyte.Parse(reader["id_oddzialu"].ToString());
            Adres = reader["adres"].ToString();
            NrTelefonu = reader["nr_telefonu"].ToString();
            Nazwa = reader["nazwa"].ToString();
        }

        public Oddzial(string adres, string nrtelefonu, string nazwa)
        {
            IdOddzialu = null;
            Adres = adres.Trim();
            NrTelefonu = nrtelefonu.Trim();
            Nazwa = nazwa.Trim();
        }

        public Oddzial(Oddzial oddzial)
        {
            IdOddzialu = oddzial.IdOddzialu;
            Adres = oddzial.Adres;
            NrTelefonu = oddzial.NrTelefonu;
            Nazwa = oddzial.Nazwa;
        }
    }

}

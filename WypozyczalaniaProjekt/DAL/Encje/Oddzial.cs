using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Oddzial
    {

        #region Własności

        public sbyte? IdOddzialu { get; set; }
        public string Adres { get; set; }
        public string NrTelefonu { get; set; }
        public string Nazwa { get; set; }

        #endregion

        #region Konstruktory

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

        #endregion

        #region Metody

        public override string ToString()
        {
            return Nazwa + ", " + Adres;
        }
        public string ToInsert()
        {
            return $"('{Adres}','{NrTelefonu}','{Nazwa}')";
        }

        public override bool Equals(object obj)
        {
            var oddzial = obj as Oddzial;
            if (oddzial is null) return false;
            if (!Adres.ToLower().Equals(oddzial.Adres.ToLower())) return false;
            if (!NrTelefonu.ToLower().Equals(oddzial.NrTelefonu.ToLower())) return false;
            if (!Nazwa.ToLower().Equals(oddzial.Nazwa.ToLower())) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}

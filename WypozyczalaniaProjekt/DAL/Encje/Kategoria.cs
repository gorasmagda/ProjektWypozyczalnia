using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Kategoria
    {

        #region Własności

        public string Nazwa { get; set; }
        public string Opis { get; set; }

        #endregion

        #region Konstruktory

        public Kategoria(MySqlDataReader reader)
        {
            Nazwa = reader["nazwa"].ToString();
            Opis = reader["opis"].ToString();
        }

        public Kategoria(string nazwa, string opis)
        {
            Nazwa = nazwa.Trim();
            Opis = opis.Trim();
        }

        public Kategoria(Kategoria kategoria)
        {
            Nazwa = kategoria.Nazwa;
            Opis = kategoria.Opis;
        }

        #endregion

        #region Metody

        public override string ToString()
        {
            return Nazwa;
        }

        public override bool Equals(object obj)
        {
            var kategoria = obj as Kategoria;
            if (kategoria is null) return false;
            if (!Opis.ToLower().Equals(kategoria.Opis.ToLower())) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}

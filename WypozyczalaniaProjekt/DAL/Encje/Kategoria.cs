using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Kategoria
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }

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

    }
}

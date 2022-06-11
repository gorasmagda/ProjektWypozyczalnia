using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Samochod
    {
        public sbyte? IdAuto { get; set; }
        public string Marka { get; set; }
        public string ModelAuta { get; set; }
        public int Rocznik { get; set; }
        public string Kolor { get; set; }
        public int IloscMiejsc { get; set; }
        public string Skrzynia { get; set; }
        public string NrRejestracyjny { get; set; }
        public string Lokalizacja { get; set; }
        public decimal Cena { get; set; }
        public string Kaucja { get; set; }
        public int Przebieg { get; set; }
        public string Dostepnosc { get; set; }
        public sbyte? IdOddzial { get; set; }
        public string Kategoria { get; set; }

        public Samochod(MySqlDataReader reader)
        {
            IdAuto = sbyte.Parse(reader["id_auto"].ToString());
            Marka = reader["marka"].ToString();
            ModelAuta = reader["model"].ToString();
            Rocznik = int.Parse(reader["rocznik"].ToString());
            Kolor = reader["kolor"].ToString();
            IloscMiejsc = int.Parse(reader["ilosc_miejsc"].ToString());
            Skrzynia = reader["skrzynia"].ToString();
            NrRejestracyjny = reader["nr_rejestracyjny"].ToString();
            Lokalizacja = reader["aktualna_lokalizacja"].ToString();
            Cena = decimal.Parse(reader["cena"].ToString());
            Kaucja = reader["kaucja"].ToString();
            Przebieg = int.Parse(reader["przebieg"].ToString());
            Dostepnosc = reader["dostepnosc"].ToString();
            IdOddzial = sbyte.Parse(reader["id_oddzialu"].ToString());
            Kategoria = reader["kategoria"].ToString();
        }

        public Samochod(string marka, string model, int rocznik, string kolor, int iloscMiejsc, string skrzynia, string nrRejestracyjny, string aktualnaLokalizacja, decimal cena, string kaucja, int przebieg, string dostepnosc, sbyte? idOddzialu, string nazwa)
        {
            IdAuto = null;
            Marka = marka.Trim();
            ModelAuta = model.Trim();
            Rocznik = rocznik;
            Kolor = kolor.Trim();
            IloscMiejsc = iloscMiejsc;
            Skrzynia = skrzynia;
            NrRejestracyjny = nrRejestracyjny;
            Lokalizacja = aktualnaLokalizacja;
            Cena = cena;
            Kaucja = kaucja;
            Przebieg = przebieg;
            Dostepnosc = dostepnosc;
            IdOddzial = idOddzialu;
            Kategoria = nazwa;
        }

        public Samochod(Samochod samochod)
        {
            IdAuto = samochod.IdAuto;
            Marka = samochod.Marka;
            ModelAuta = samochod.ModelAuta;
            Rocznik = samochod.Rocznik;
            Kolor = samochod.Kolor;
            IloscMiejsc = samochod.IloscMiejsc;
            Skrzynia = samochod.Skrzynia;
            NrRejestracyjny = samochod.NrRejestracyjny;
            Lokalizacja = samochod.Lokalizacja;
            Cena = samochod.Cena;
            Kaucja = samochod.Kaucja;
            Przebieg = samochod.Przebieg;
            Dostepnosc = samochod.Dostepnosc;
            IdOddzial = samochod.IdOddzial;
            Kategoria = samochod.Kategoria;
        }

        public override string ToString()
        {
            return IdAuto + ", " + Marka + ", " + ModelAuta + ", " + Kolor + ", " + Rocznik + ", " + Kategoria;
        }

        public string ToInsert()
        {

            return $"('{Marka}','{ModelAuta}','{Rocznik}','{Kolor}',{IloscMiejsc},'{Skrzynia}','{NrRejestracyjny}','{Lokalizacja}',{Cena},'{Kaucja}','{Przebieg}','{Dostepnosc}',{IdOddzial},{Kategoria})";

        }

        //TO DO DKOKOŃCZYĆ 
        public override bool Equals(object obj)
        {
            var samochod = obj as Samochod;
            if (samochod is null) return false;
            if (Marka.ToLower() != samochod.Marka.ToLower()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

using MySql.Data.MySqlClient;

namespace WypozyczalaniaProjekt.DAL.Encje
{
    class Samochod
    {

        #region Własności

        public sbyte? IdAuto { get; set; }
        public string Marka { get; set; }
        public string ModelAuta { get; set; }
        public int Rocznik { get; set; }
        public string Kolor { get; set; }
        public int IloscMiejsc { get; set; }
        public string Skrzynia { get; set; }
        public string NrRejestracyjny { get; set; }
        public string Lokalizacja { get; set; }
        public string Cena { get; set; }
        public string Kaucja { get; set; }
        public int Przebieg { get; set; }
        public string Dostepnosc { get; set; }
        public sbyte? IdOddzial { get; set; }
        public string Kategoria { get; set; }
        public string Silnik { get; set; }
        public int Moc { get; set; }

        #endregion

        #region Konstruktory

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
            Cena = reader["cena"].ToString();
            Kaucja = reader["kaucja"].ToString();
            Przebieg = int.Parse(reader["przebieg"].ToString());
            Dostepnosc = reader["dostepnosc"].ToString();
            IdOddzial = sbyte.Parse(reader["id_oddzialu"].ToString());
            Kategoria = reader["kategoria"].ToString();
            Silnik = reader["silnik"].ToString();
            Moc = int.Parse(reader["moc"].ToString()) ;
        }

        public Samochod(string marka, string model, int rocznik, string kolor, int iloscMiejsc, string skrzynia, string nrRejestracyjny, string aktualnaLokalizacja, string cena, string kaucja, int przebieg, string dostepnosc, sbyte? idOddzialu, string nazwa, string silnik, int moc)
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
            Silnik = silnik;
            Moc = moc;
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
            Silnik = samochod.Silnik;
            Moc = samochod.Moc;
        }

        #endregion

        #region Metody

        public override string ToString()
        {
            return IdAuto + ", " + Marka + ", " + ModelAuta + ", " + Kolor + ", " + Rocznik + ", " + Kategoria;
        }

        public string ToInsert()
        {
            return $"('{Marka}','{ModelAuta}','{Rocznik}','{Kolor}',{IloscMiejsc},'{Skrzynia}','{NrRejestracyjny}','{Lokalizacja}',{Cena},'{Kaucja}','{Przebieg}','{Dostepnosc}',{IdOddzial},'{Kategoria}')";
        }

        public override bool Equals(object obj)
        {
            var samochod = obj as Samochod;
            if (samochod is null) return false;
            if (Marka.ToLower() != samochod.Marka.ToLower()) return false;
            if (!ModelAuta.ToLower().Equals(samochod.ModelAuta.ToLower())) return false;
            if (!Rocznik.Equals(samochod.Rocznik)) return false;
            if (!Kolor.ToLower().Equals(samochod.Kolor.ToLower())) return false;
            if (!IloscMiejsc.Equals(samochod.IloscMiejsc)) return false;
            if (!Skrzynia.ToLower().Equals(samochod.Skrzynia.ToLower())) return false;
            if (!NrRejestracyjny.ToLower().Equals(samochod.NrRejestracyjny.ToLower())) return false;
            if (!Lokalizacja.ToLower().Equals(samochod.Lokalizacja.ToLower())) return false;
            if (!Cena.ToLower().Equals(samochod.Cena.ToLower())) return false;
            if (!Kaucja.ToLower().Equals(samochod.Kaucja.ToLower())) return false;
            if (!Przebieg.Equals(samochod.Przebieg)) return false;
            if (!Dostepnosc.ToLower().Equals(samochod.Dostepnosc.ToLower())) return false;
            if (!IdOddzial.Equals(samochod.IdOddzial)) return false;
            if (!Kategoria.ToLower().Equals(samochod.Kategoria.ToLower())) return false;
            if (!Silnik.ToLower().Equals(samochod.Silnik.ToLower())) return false;
            if (!Moc.Equals(samochod.Moc)) return false;
            
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}

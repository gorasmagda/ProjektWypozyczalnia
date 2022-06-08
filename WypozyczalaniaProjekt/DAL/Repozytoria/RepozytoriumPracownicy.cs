using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;
    class RepozytoriumPracownicy
    {
        #region ZAPYTANIA
        private const string WSZYSCY_PRACOWNICY = "SELECT * FROM pracownicy";
        #endregion

        #region metody CRUD
        public static List<Pracownik> PobierzWszystkichPracownikow()
        {
            List<Pracownik> pracownicy = new List<Pracownik>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_PRACOWNICY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    pracownicy.Add(new Pracownik(reader));
                connection.Close();

            }
            return pracownicy;
        }
        #endregion
    }
}

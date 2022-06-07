using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalaniaProjekt.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;

    class RepozytoriumSamochody
    {

        #region ZAPYTANIA
        private const string WSZYSTKIE_SAMOCHODY = "SELECT * FROM samochody";
        #endregion

        #region metody CRUD
        public static List<Samochod> PobierzWszystkieSamochody()
        {
            List<Samochod> samochody = new List<Samochod>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_SAMOCHODY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                //while (reader.Read())
                //    samochody.Add(new Samochody(reader));
                connection.Close();

            }
            return samochody;
        }


        #endregion

    }
}

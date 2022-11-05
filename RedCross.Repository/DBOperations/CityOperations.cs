using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class CityOperations
    {
        public static List<CityModel> GetCities(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM City";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<CityModel> result = new List<CityModel>();

                    while (reader.Read())
                    {
                        CityModel city = new CityModel();
                        city.CityName = reader.GetString(0);
                        result.Add(city);
                    }

                    connection.Close();

                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

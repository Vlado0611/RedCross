using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class PositionOperations
    {
        public static List<PositionModel> GetPositions(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Position";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<PositionModel> result = new List<PositionModel>();

                    while (reader.Read())
                    {
                        PositionModel position = new PositionModel();
                        position.PositionName = reader.GetString(0);
                        result.Add(position);
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

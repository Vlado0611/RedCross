using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class StatusOperations
    {
        public static List<StatusModel> GetStatuses(string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Status";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<StatusModel> result = new List<StatusModel>();

                    while (reader.Read())
                    {
                        StatusModel status = new StatusModel();
                        status.StatusName = reader.GetString(0);
                        result.Add(status);
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

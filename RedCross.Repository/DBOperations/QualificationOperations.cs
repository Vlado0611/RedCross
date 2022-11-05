using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class QualificationOperations
    {
        public static List<QualificationModel> GetQualifications(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Qualification";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<QualificationModel> result = new List<QualificationModel>();

                    while (reader.Read())
                    {
                        QualificationModel qualification = new QualificationModel();
                        qualification.QualificationName = reader.GetString(0);
                        result.Add(qualification);
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

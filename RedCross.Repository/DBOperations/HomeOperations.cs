using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class HomeOperations
    {
        public static HomeModel GetHomeModel(string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT COUNT(*) FROM Employee e INNER JOIN Member m ON e.EmployeeID = m.MemberID " +
                        "WHERE m.Deleted = 0";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read();
                    HomeModel home = new HomeModel();
                    home.EmployeeNo = reader.GetInt32(0);
                    reader.Close();

                    selectCommand.CommandText = "SELECT COUNT(*) FROM Volunteer v INNER JOIN Member m ON v.VolunteerID = m.MemberID " +
                        "WHERE m.Deleted = 0";

                    reader = selectCommand.ExecuteReader();
                    reader.Read();
                    home.VolunteerNo = reader.GetInt32(0);
                    reader.Close();

                    selectCommand.CommandText = "SELECT COUNT(*) FROM Aid";

                    reader = selectCommand.ExecuteReader();
                    reader.Read();
                    home.ActionNo = reader.GetInt32(0);
                    reader.Close();

                    selectCommand.CommandText = "SELECT COUNT(*) FROM Beneficiary WHERE Deleted = 0";

                    reader = selectCommand.ExecuteReader();
                    reader.Read();
                    home.BeneficiaryNo = reader.GetInt32(0);
                    reader.Close();

                    connection.Close();

                    return home;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class MemberOperations
    {
        public static List<MemberModel> GetMembers(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Member";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<MemberModel> result = new List<MemberModel>();

                    while (reader.Read())
                    {
                        MemberModel member = new MemberModel();
                        member.MemberID = reader.GetInt32(0);
                        member.Name = reader.GetString(1);
                        member.Surname = reader.GetString(2);
                        member.CUID = reader.GetString(3);
                        member.AdmissionDate = reader.GetDateTime(4);
                        member.City = reader.GetString(5);

                        result.Add(member);
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

        public static MemberModel GetMemberByID(int memberID, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM member WHERE memberID = @memberID";
                    selectCommand.Parameters.AddWithValue("memberID", memberID);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    reader.Read();

                    MemberModel member = new MemberModel();
                    member.MemberID = reader.GetInt32(0);
                    member.Name = reader.GetString(1);
                    member.Surname = reader.GetString(2);
                    member.CUID = reader.GetString(3);
                    member.AdmissionDate = reader.GetDateTime(4);
                    member.City = reader.GetString(5);

                    connection.Close();

                    return member;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

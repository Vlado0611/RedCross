using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class BeneficiaryOperations
    {
        public static List<BeneficiaryModel> GetBeneficiaries(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Beneficiary WHERE Deleted = 0";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<BeneficiaryModel> result = new List<BeneficiaryModel>();

                    while (reader.Read())
                    {
                        BeneficiaryModel beneficiary = new BeneficiaryModel();
                        beneficiary.BeneficiaryID = reader.GetInt32(0);
                        beneficiary.Name = reader.GetString(1);
                        beneficiary.Surname = reader.GetString(2);
                        beneficiary.CUID = reader.GetString(3);
                        beneficiary.Priority = reader.GetInt32(4);
                        beneficiary.City = reader.GetString(5);

                        result.Add(beneficiary);
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

        public static BeneficiaryModel GetBeneficiaryByID(int id, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {

                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;

                    selectCommand.CommandText = "SELECT * FROM Beneficiary WHERE BeneficiaryID=@BeneficiaryID AND Deleted = 0";
                    selectCommand.Parameters.AddWithValue("BeneficiaryID", id);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    reader.Read();

                    BeneficiaryModel beneficiary = new BeneficiaryModel();
                    beneficiary.BeneficiaryID = reader.GetInt32(0);
                    beneficiary.Name = reader.GetString(1);
                    beneficiary.Surname = reader.GetString(2);
                    beneficiary.CUID = reader.GetString(3);
                    beneficiary.Priority = reader.GetInt32(4);
                    beneficiary.City = reader.GetString(5);

                    connection.Close();

                    return beneficiary;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool DeleteBeneficiary(int beneficiaryID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "UPDATE Beneficiary SET Deleted = 1 WHERE BeneficiaryID = @BeneficiaryID";
                    deleteCommand.Parameters.AddWithValue("BeneficiaryID", beneficiaryID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool InsertBeneficiary(BeneficiaryModel beneficiary, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Beneficiary (Name, Surname, CUID, Priority, City, Deleted)" +
                        " VALUES (@Name, @Surname, @CUID, @Priority, @City, 0)";
                    insertCommand.Parameters.AddWithValue("Name", beneficiary.Name);
                    insertCommand.Parameters.AddWithValue("Surname", beneficiary.Surname);
                    insertCommand.Parameters.AddWithValue("CUID", beneficiary.CUID);
                    insertCommand.Parameters.AddWithValue("Priority", beneficiary.Priority);
                    insertCommand.Parameters.AddWithValue("City", beneficiary.City);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();
                    return rowsAffected == 1;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool UpdateBeneficiary(BeneficiaryModel beneficiary, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Beneficiary " +
                        "SET Name = @Name, " +
                        "Surname = @Surname, " +
                        "CUID = @CUID, " +
                        "Priority = @Priority, " +
                        "City = @City " +
                        "WHERE BeneficiaryID = @BeneficiaryID";

                    updateCommand.Parameters.AddWithValue("Name", beneficiary.Name);
                    updateCommand.Parameters.AddWithValue("Surname", beneficiary.Surname);
                    updateCommand.Parameters.AddWithValue("CUID", beneficiary.CUID);
                    updateCommand.Parameters.AddWithValue("Priority", beneficiary.Priority);
                    updateCommand.Parameters.AddWithValue("City", beneficiary.City);
                    updateCommand.Parameters.AddWithValue("BeneficiaryID", beneficiary.BeneficiaryID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected == 1;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

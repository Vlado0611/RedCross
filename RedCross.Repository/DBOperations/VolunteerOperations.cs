using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class VolunteerOperations
    {
        public static List<VolunteerModel> GetVolunteers(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Volunteer";

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<VolunteerModel> volunteers = new List<VolunteerModel>();

                    while (reader.Read())
                    {
                        VolunteerModel volunteer = new VolunteerModel();
                        volunteer.VolunteerID = reader.GetInt32(0);
                        volunteer.ActionNo = reader.GetInt32(1);
                        volunteer.LastAction = reader.GetDateTime(2);
                        volunteer.Status = reader.GetString(3);

                        volunteers.Add(volunteer);
                    }
                    connection.Close();

                    return volunteers;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static VolunteerModel GetVolunteerByID(int volunteerID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT v.VolunteerID, m.Name, m.Surname, " +
                        "m.CUID, m.AdmissionDate, m.City, v.ActionNo, v.LastAction, v.[Status]" +
                        "FROM Volunteer v INNER JOIN Member m ON v.VolunteerID = m.MemberID " +
                        "WHERE v.VolunteerID=@VolunteerID";
                    selectCommand.Parameters.AddWithValue("VolunteerID", volunteerID);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    reader.Read();

                    VolunteerModel volunteer = new VolunteerModel();
                    volunteer.VolunteerID = reader.GetInt32(0);
                    volunteer.Name = reader.GetString(1);
                    volunteer.Surname = reader.GetString(2);
                    volunteer.CUID = reader.GetString(3);
                    volunteer.AdmissionDate = reader.GetDateTime(4);
                    volunteer.City = reader.GetString(5);
                    volunteer.ActionNo = reader.GetInt32(6);
                    volunteer.LastAction = reader.GetDateTime(7);
                    volunteer.Status = reader.GetString(8);

                    connection.Close();

                    return volunteer;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<VolunteerModel> GetVolunteersFullDetails(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT v.VolunteerID, m.Name, m.Surname, v.ActionNo, v.LastAction, v.Status " +
                        "FROM Volunteer v INNER JOIN Member m ON v.VolunteerID = m.MemberID WHERE m.Deleted = 0";

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<VolunteerModel> volunteers = new List<VolunteerModel>();

                    while (reader.Read())
                    {
                        VolunteerModel volunteer = new VolunteerModel();
                        volunteer.VolunteerID = reader.GetInt32(0);
                        volunteer.Name = reader.GetString(1);
                        volunteer.Surname = reader.GetString(2);
                        volunteer.VolunteerName = reader.GetString(1);
                        volunteer.VolunteerSurname = reader.GetString(2);
                        volunteer.ActionNo = reader.GetInt32(3);
                        volunteer.LastAction = reader.GetDateTime(4);
                        volunteer.Status = reader.GetString(5);

                        volunteers.Add(volunteer);
                    }
                    connection.Close();

                    return volunteers;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool DeleteVolunteer(int volunteerID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    /*
                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Volunteer WHERE VolunteerID = @VolunteerID";
                    deleteCommand.Parameters.AddWithValue("VolunteerID", volunteerID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    */
                    //if(rowsAffected == 1)
                    //{
                    SqlCommand deleteMemberCommand = new SqlCommand();
                    deleteMemberCommand.Connection = connection;
                    //deleteMemberCommand.CommandText = "DELETE FROM Member WHERE MemberID = @MemberID";
                    //deleteMemberCommand.Parameters.AddWithValue("@MemberID", volunteerID);

                    deleteMemberCommand.CommandText = "UPDATE Member SET Deleted = 1 WHERE MemberID = @MemberID";
                    deleteMemberCommand.Parameters.AddWithValue("@MemberID", volunteerID);

                    int rowsAffected = deleteMemberCommand.ExecuteNonQuery();

                    //    return rowsAffected == 1;
                    //}

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool InsertVolunteer(VolunteerModel volunteer, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Member (Name, Surname, CUID, AdmissionDate, City, Deleted) " +
                        "VALUES (@Name, @Surname, @CUID, @AdmissionDate, @City, 0)";
                    insertCommand.Parameters.AddWithValue("Name", volunteer.Name);
                    insertCommand.Parameters.AddWithValue("Surname", volunteer.Surname);
                    insertCommand.Parameters.AddWithValue("CUID", volunteer.CUID);
                    insertCommand.Parameters.AddWithValue("AdmissionDate", volunteer.AdmissionDate);
                    insertCommand.Parameters.AddWithValue("City", volunteer.City);


                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        SqlCommand selectCommand = new SqlCommand();
                        selectCommand.Connection = connection;
                        selectCommand.CommandText = "SELECT MemberID FROM Member WHERE CUID = @CUID";
                        selectCommand.Parameters.AddWithValue("CUID", volunteer.CUID);

                        SqlDataReader reader = selectCommand.ExecuteReader();

                        reader.Read();
                        int id = reader.GetInt32(0);
                        reader.Close();

                        SqlCommand insertVolunteerCommand = new SqlCommand();
                        insertVolunteerCommand.Connection = connection;
                        insertVolunteerCommand.CommandText = "INSERT INTO Volunteer (VolunteerID, ActionNo, LastAction, Status) " +
                            "VALUES (@VolunteerID, 0, @LastAction, @Status) ";
                        insertVolunteerCommand.Parameters.AddWithValue("VolunteerID", id);
                        insertVolunteerCommand.Parameters.AddWithValue("LastAction", DateTime.Now);
                        insertVolunteerCommand.Parameters.AddWithValue("Status", volunteer.Status);

                        rowsAffected = insertVolunteerCommand.ExecuteNonQuery();

                        connection.Close();
                        return rowsAffected == 1;
                    }
                    connection.Close();
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool UpdateVolunteer(VolunteerModel volunteer, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Member SET Name = @Name, Surname = @Surname, CUID = @CUID, " +
                        "AdmissionDate = @AdmissionDate, City = @City WHERE MemberID = @MemberID";
                    updateCommand.Parameters.AddWithValue("Name", volunteer.Name);
                    updateCommand.Parameters.AddWithValue("Surname", volunteer.Surname);
                    updateCommand.Parameters.AddWithValue("CUID", volunteer.CUID);
                    updateCommand.Parameters.AddWithValue("AdmissionDate", volunteer.AdmissionDate);
                    updateCommand.Parameters.AddWithValue("City", volunteer.City);
                    updateCommand.Parameters.AddWithValue("MemberID", volunteer.VolunteerID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {

                        SqlCommand updateVolunteerCommand = new SqlCommand();
                        updateVolunteerCommand.Connection = connection;
                        updateVolunteerCommand.CommandText = "UPDATE Volunteer " +
                            "SET ActionNo = @ActionNo, LastAction = @LastAction, Status = @Status WHERE VolunteerID=@VolunteerID";

                        updateVolunteerCommand.Parameters.AddWithValue("ActionNo", volunteer.ActionNo);
                        updateVolunteerCommand.Parameters.AddWithValue("LastAction", volunteer.LastAction);
                        updateVolunteerCommand.Parameters.AddWithValue("Status", volunteer.Status);
                        updateVolunteerCommand.Parameters.AddWithValue("VolunteerID", volunteer.VolunteerID);

                        rowsAffected = updateVolunteerCommand.ExecuteNonQuery();

                        connection.Close();
                        return rowsAffected == 1;
                    }
                    connection.Close();
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static VolunteerModel GetVolunteerFullDetailsByID(int id, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT v.VolunteerID, m.Name, m.Surname, m.CUID, m.AdmissionDate, m.City, " +
                        "v.ActionNo, v.LastAction, v.Status " +
                        "FROM Volunteer v INNER JOIN Member m ON v.VolunteerID = m.MemberID WHERE m.Deleted = 0 AND VolunteerID = @VolunteerID";
                    selectCommand.Parameters.AddWithValue("VolunteerID", id);
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    reader.Read();
                    VolunteerModel volunteer = new VolunteerModel();
                    volunteer.VolunteerID = reader.GetInt32(0);
                    volunteer.Name = reader.GetString(1);
                    volunteer.Surname = reader.GetString(2);
                    volunteer.CUID = reader.GetString(3);
                    volunteer.AdmissionDate = reader.GetDateTime(4);
                    volunteer.City = reader.GetString(5);
                    volunteer.ActionNo = reader.GetInt32(6);
                    volunteer.LastAction = reader.GetDateTime(7);
                    volunteer.Status = reader.GetString(8);

                    connection.Close();

                    return volunteer;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

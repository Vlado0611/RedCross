using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class ActionOperations
    {
        public static List<ActionModel> GetActions(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Aid";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<ActionModel> actions = new List<ActionModel>();

                    while (reader.Read())
                    {
                        ActionModel action = new ActionModel();
                        action.ActionID = reader.GetInt32(0);
                        action.BeneficiaryID = reader.GetInt32(1);
                        action.VolunteerID = reader.GetInt32(2);
                        action.ActionDate = reader.GetDateTime(3);
                        action.Title = reader.GetString(4);
                        action.Description = reader.GetString(5);

                        actions.Add(action);
                    }

                    connection.Close();

                    return actions;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static ActionModel GetActionByActionID(int id, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT a.AidID, b.BeneficiaryID, b.Name, b.Surname, " +
                        "m.MemberID, m.Name, m.Surname, a.ActionDate, a.Title, a.Description" +
                        " FROM Aid a, Member m, Beneficiary b" +
                        " WHERE a.BeneficiaryID = b.BeneficiaryID AND a.VolunteerID = m.MemberID AND a.AidID = @ActionID";
                    selectCommand.Parameters.AddWithValue("ActionID", id);

                    SqlDataReader reader = selectCommand.ExecuteReader();


                    reader.Read();

                    ActionModel action = new ActionModel();
                    action.ActionID = reader.GetInt32(0);
                    action.BeneficiaryID = reader.GetInt32(1);
                    action.BeneficiaryName = reader.GetString(2);
                    action.BeneficiarySurname = reader.GetString(3);
                    action.VolunteerID = reader.GetInt32(4);
                    action.VolunteerName = reader.GetString(5);
                    action.VolunteerSurname = reader.GetString(6);
                    action.ActionDate = reader.GetDateTime(7);
                    action.Title = reader.GetString(8);
                    action.Description = reader.GetString(9);

                    connection.Close();

                    return action;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<ActionModel> GetActionsByBeneficiaryID(int id, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT a.AidID, v.MemberID, v.Name, v.Surname, " +
                        " a.ActionDate, a.Title" +
                        " FROM Aid a INNER JOIN Member v ON a.VolunteerID = v.MemberID" +
                        " WHERE BeneficiaryID=@BeneficiaryID";
                    selectCommand.Parameters.AddWithValue("BeneficiaryID", id);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<ActionModel> actions = new List<ActionModel>();

                    while (reader.Read())
                    {
                        ActionModel action = new ActionModel();
                        action.ActionID = reader.GetInt32(0);
                        action.BeneficiaryID = id;
                        action.VolunteerID = reader.GetInt32(1);
                        action.VolunteerName = reader.GetString(2);
                        action.VolunteerSurname = reader.GetString(3);
                        action.ActionDate = reader.GetDateTime(4);
                        action.Title = reader.GetString(5);
                        actions.Add(action);
                    }

                    connection.Close();

                    return actions;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<ActionModel> GetActionsByVolunteerID(int id, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT a.AidID, b.BeneficiaryID, b.Name, b.Surname, " +
                        " a.ActionDate, a.Title, a.Description" +
                        " FROM Aid a INNER JOIN Beneficiary b ON a.BeneficiaryID = b.BeneficiaryID" +
                        " WHERE VolunteerID=@VolunteerID";
                    selectCommand.Parameters.AddWithValue("VolunteerID", id);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<ActionModel> actions = new List<ActionModel>();

                    while (reader.Read())
                    {
                        ActionModel action = new ActionModel();
                        action.ActionID = reader.GetInt32(0);
                        action.BeneficiaryID = reader.GetInt32(1);
                        action.BeneficiaryName = reader.GetString(2);
                        action.BeneficiarySurname = reader.GetString(3);
                        action.VolunteerID = id;
                        action.ActionDate = reader.GetDateTime(4);
                        action.Title = reader.GetString(5);
                        action.Description = reader.GetString(6);

                        actions.Add(action);
                    }

                    connection.Close();

                    return actions;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<ActionModel> GetActionsFullDetails(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT a.AidID, b.BeneficiaryID, b.Name, b.Surname, " +
                        "m.MemberID, m.Name, m.Surname, a.ActionDate, a.Title, a.Description" +
                        " FROM Aid a, Member m, Beneficiary b" +
                        " WHERE a.BeneficiaryID = b.BeneficiaryID AND a.VolunteerID = m.MemberID";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<ActionModel> actions = new List<ActionModel>();

                    while (reader.Read())
                    {
                        ActionModel action = new ActionModel();
                        action.ActionID = reader.GetInt32(0);
                        action.BeneficiaryID = reader.GetInt32(1);
                        action.BeneficiaryName = reader.GetString(2);
                        action.BeneficiarySurname = reader.GetString(3);
                        action.VolunteerID = reader.GetInt32(4);
                        action.VolunteerName = reader.GetString(5);
                        action.VolunteerSurname = reader.GetString(6);
                        action.ActionDate = reader.GetDateTime(7);
                        action.Title = reader.GetString(8);
                        action.Description = reader.GetString(9);

                        actions.Add(action);
                    }

                    connection.Close();

                    return actions;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool DeleteAction(int actionID, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Aid WHERE AidID = @ActionID";
                    deleteCommand.Parameters.AddWithValue("ActionID", actionID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    return rowsAffected != 0;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool InsertAction(ActionModel action, string connectionString) 
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Aid(BeneficiaryID, VolunteerID, ActionDate, Title, Description) " +
                        "VALUES(@BeneficiaryID, @VolunteerID, @Date, @Title, @Description)";
                    insertCommand.Parameters.AddWithValue("BeneficiaryID", action.BeneficiaryID);
                    insertCommand.Parameters.AddWithValue("VolunteerID", action.VolunteerID);
                    insertCommand.Parameters.AddWithValue("Date", action.ActionDate);
                    insertCommand.Parameters.AddWithValue("Title", action.Title);
                    insertCommand.Parameters.AddWithValue("Description", action.Description);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected != 0;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool UpdateAction(ActionModel action, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Aid " +
                        "SET BeneficiaryID = @BeneficiaryID, " +
                        "VolunteerID = @VolunteerID, " +
                        "ActionDate = @Date, " +
                        "Title = @Title, " +
                        "Description = @Description " +
                        "WHERE AidID = @ActionID";

                    updateCommand.Parameters.AddWithValue("BeneficiaryID", action.BeneficiaryID);
                    updateCommand.Parameters.AddWithValue("VolunteerID", action.VolunteerID);
                    updateCommand.Parameters.AddWithValue("Date", action.ActionDate);
                    updateCommand.Parameters.AddWithValue("Title", action.Title);
                    updateCommand.Parameters.AddWithValue("Description", action.Description);
                    updateCommand.Parameters.AddWithValue("ActionID", action.ActionID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected != 0;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class UserOperations
    {
        public static UserModel Login(UserModel userData, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password";
                    selectCommand.Parameters.AddWithValue("Username", userData.Username);
                    selectCommand.Parameters.AddWithValue("Password", userData.Password);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    }
                    userData.Email = reader.GetString(2);
                    userData.Name = reader.GetString(3);
                    userData.Surname = reader.GetString(4);
                    userData.Admin = reader.GetInt32(5);
                    userData.UserID = reader.GetInt32(6);

                    return userData;

                    connection.Close();
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool InsertUser(UserModel userData, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO [User](Username, Password, Email, Name, Surname, Admin) " +
                        "VALUES (@Username, @Password, @Email, @Name, @Surname, 0)";
                    insertCommand.Parameters.AddWithValue("Username", userData.Username);
                    insertCommand.Parameters.AddWithValue("Password", userData.Password);
                    insertCommand.Parameters.AddWithValue("Email", userData.Email);
                    insertCommand.Parameters.AddWithValue("Name", userData.Name);
                    insertCommand.Parameters.AddWithValue("Surname", userData.Surname);

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

        public static bool UpdateUser(UserModel userData, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE [User] " +
                        "SET Username=@Username," +
                        "Password=@Password," +
                        "Email=@Email," +
                        "Name=@Name," +
                        "Surname=@Surname," +
                        "Admin=@Admin " +
                        "WHERE UserID = @UserID";
                    updateCommand.Parameters.AddWithValue("Username", userData.Username);
                    updateCommand.Parameters.AddWithValue("Password", userData.Password);
                    updateCommand.Parameters.AddWithValue("Email", userData.Email);
                    updateCommand.Parameters.AddWithValue("Name", userData.Name);
                    updateCommand.Parameters.AddWithValue("Surname", userData.Surname);
                    updateCommand.Parameters.AddWithValue("Admin", userData.Admin);
                    updateCommand.Parameters.AddWithValue("UserID", userData.UserID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

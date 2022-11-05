using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.DBOperations
{
    public class EmployeeOperations
    {
        public static List<EmployeeModel> GetEmployees(string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Employee";

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<EmployeeModel> employees = new List<EmployeeModel>();

                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.EmployeeID = reader.GetInt32(0);
                        employee.QualificationName = reader.GetString(1);
                        employee.PositionName = reader.GetString(2);

                        employees.Add(employee);
                    }

                    connection.Close();

                    return employees;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public static EmployeeModel GetEmployeeByID(int employeeID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT e.EmployeeID, m.Name, m.Surname, " +
                        "m.CUID, m.AdmissionDate, m.City, e.QualificationName, e.PositionName " +
                        " FROM Employee e INNER JOIN Member m ON e.EmployeeID = m.MemberID" +
                        " WHERE EmployeeID=@EmployeeID";
                    selectCommand.Parameters.AddWithValue("EmployeeID", employeeID);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    reader.Read();
                    
                    EmployeeModel employee = new EmployeeModel();
                    employee.EmployeeID = reader.GetInt32(0);
                    employee.Name = reader.GetString(1);
                    employee.Surname = reader.GetString(2);
                    employee.CUID = reader.GetString(3);
                    employee.AdmissionDate = reader.GetDateTime(4);
                    employee.City = reader.GetString(5);
                    employee.QualificationName = reader.GetString(6);
                    employee.PositionName = reader.GetString(7);

                    connection.Close();

                    return employee;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<EmployeeModel> GetEmployeesFullDetails(string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT e.EmployeeID, m.Name, m.Surname, e.QualificationName, e.PositionName " +
                        "FROM Employee e INNER JOIN Member m ON e.EmployeeID = m.MemberID WHERE m.Deleted = 0";

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<EmployeeModel> employees = new List<EmployeeModel>();

                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.EmployeeID = reader.GetInt32(0);
                        employee.EmployeeName = reader.GetString(1);
                        employee.EmployeeSurname = reader.GetString(2);
                        employee.QualificationName = reader.GetString(3);
                        employee.PositionName = reader.GetString(4);

                        employees.Add(employee);
                    }

                    connection.Close();

                    return employees;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public static EmployeeModel GetEmployeeFullDetailsByID(int id, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT e.EmployeeID, m.Name, m.Surname, m.CUID, m.AdmissionDate, m.City, e.QualificationName, e.PositionName " +
                        "FROM Employee e INNER JOIN Member m ON e.EmployeeID = m.MemberID WHERE m.Deleted = 0 AND EmployeeID = @EmployeeID";
                    selectCommand.Parameters.AddWithValue("EmployeeID", id);
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    reader.Read();
                    EmployeeModel employee = new EmployeeModel();
                    employee.EmployeeID = reader.GetInt32(0);
                    employee.Name = reader.GetString(1);
                    employee.Surname = reader.GetString(2);
                    employee.CUID = reader.GetString(3);
                    employee.AdmissionDate = reader.GetDateTime(4);
                    employee.City = reader.GetString(5);
                    employee.QualificationName = reader.GetString(6);
                    employee.PositionName = reader.GetString(7);

                    connection.Close();

                    return employee;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool InsertEmployee(EmployeeModel employee, string connectionString)
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
                    insertCommand.Parameters.AddWithValue("Name", employee.Name);
                    insertCommand.Parameters.AddWithValue("Surname", employee.Surname);
                    insertCommand.Parameters.AddWithValue("CUID", employee.CUID);
                    insertCommand.Parameters.AddWithValue("AdmissionDate", employee.AdmissionDate);
                    insertCommand.Parameters.AddWithValue("City", employee.City);

                    
                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        SqlCommand selectCommand = new SqlCommand();
                        selectCommand.Connection = connection;
                        selectCommand.CommandText = "SELECT MemberID FROM Member WHERE CUID = @CUID";
                        selectCommand.Parameters.AddWithValue("CUID", employee.CUID);

                        SqlDataReader reader = selectCommand.ExecuteReader();

                        reader.Read();
                        int id = reader.GetInt32(0);

                        reader.Close();

                        SqlCommand insertEmployeeCommand = new SqlCommand();
                        insertEmployeeCommand.Connection = connection;
                        insertEmployeeCommand.CommandText = "INSERT INTO Employee (EmployeeID, QualificationName, PositionName) " +
                            "VALUES (@EmployeeID, @QualificationName, @PositionName) ";
                        insertEmployeeCommand.Parameters.AddWithValue("EmployeeID", id);
                        insertEmployeeCommand.Parameters.AddWithValue("QualificationName", employee.QualificationName);
                        insertEmployeeCommand.Parameters.AddWithValue("PositionName", employee.PositionName);

                        rowsAffected = insertEmployeeCommand.ExecuteNonQuery();

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

        public static bool UpdateEmployee(EmployeeModel employee, string connectionString)
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
                    updateCommand.Parameters.AddWithValue("Name", employee.Name);
                    updateCommand.Parameters.AddWithValue("Surname", employee.Surname);
                    updateCommand.Parameters.AddWithValue("CUID", employee.CUID);
                    updateCommand.Parameters.AddWithValue("AdmissionDate", employee.AdmissionDate);
                    updateCommand.Parameters.AddWithValue("City", employee.City);
                    updateCommand.Parameters.AddWithValue("MemberID", employee.EmployeeID);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        
                        SqlCommand updateEmployeeCommand = new SqlCommand();
                        updateEmployeeCommand.Connection = connection;
                        updateEmployeeCommand.CommandText = "UPDATE Employee " +
                            "SET QualificationName = @QualificationName, PositionName = @PositionName WHERE EmployeeID=@EmployeeID";

                        updateEmployeeCommand.Parameters.AddWithValue("QualificationName", employee.QualificationName);
                        updateEmployeeCommand.Parameters.AddWithValue("PositionName", employee.PositionName);
                        updateEmployeeCommand.Parameters.AddWithValue("EmployeeID", employee.EmployeeID);

                        rowsAffected = updateEmployeeCommand.ExecuteNonQuery();

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

        public static bool DeleteEmployee(int employeeID, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    /*
                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                    deleteCommand.Parameters.AddWithValue("EmployeeID", employeeID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    */
                    //if(rowsAffected == 1)
                    //{
                    SqlCommand deleteMemberCommand = new SqlCommand();
                    deleteMemberCommand.Connection = connection;
                    //deleteMemberCommand.CommandText = "DELETE FROM Member WHERE MemberID = @MemberID";
                    //deleteMemberCommand.Parameters.AddWithValue("@MemberID", employeeID);

                    deleteMemberCommand.CommandText = "UPDATE Member SET Deleted = 1 WHERE MemberID = @MemberID";
                    deleteMemberCommand.Parameters.AddWithValue("@MemberID", employeeID);

                    int rowsAffected = deleteMemberCommand.ExecuteNonQuery();

                    //    return rowsAffected == 1;
                    //}

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

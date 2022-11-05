using RedCross.Repository.DBOperations;
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        public bool DeleteEmployee(int employeeID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return EmployeeOperations.DeleteEmployee(employeeID, connectionString);
        }

        public EmployeeModel GetEmployeeByID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return EmployeeOperations.GetEmployeeByID(id, connectionString);
        }

        public List<EmployeeModel> GetEmployees()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return EmployeeOperations.GetEmployees(connectionString);
        }

        public List<EmployeeModel> GetEmployeesFullDetails()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return EmployeeOperations.GetEmployeesFullDetails(connectionString);
        }

        public EmployeeModel GetEmployeeFullDetailsByID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return EmployeeOperations.GetEmployeeFullDetailsByID(id, connectionString);
        }

        public bool InsertEmployee(EmployeeModel employee)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return EmployeeOperations.InsertEmployee(employee, connectionString);
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return EmployeeOperations.UpdateEmployee(employee, connectionString);
        }
    }
}
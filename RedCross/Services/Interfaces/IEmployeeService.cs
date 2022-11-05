using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetEmployees();
        EmployeeModel GetEmployeeByID(int id);
        List<EmployeeModel> GetEmployeesFullDetails();
        EmployeeModel GetEmployeeFullDetailsByID(int id);
        bool InsertEmployee(EmployeeModel employee);
        bool UpdateEmployee(EmployeeModel employee);
        bool DeleteEmployee(int employeeID);
    }
}
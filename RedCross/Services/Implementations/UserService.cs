using RedCross.Repository.DBOperations;
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Implementations
{
    public class UserService : IUserService
    {
        public bool InsertUser(UserModel userData)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return UserOperations.InsertUser(userData, connectionString); 
        }

        public UserModel Login(UserModel userData)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return UserOperations.Login(userData, connectionString);
        }

        public bool UpdateUser(UserModel userData)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return UserOperations.UpdateUser(userData, connectionString);
        }
    }
}
using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Login(UserModel userData);
        bool InsertUser(UserModel userData);
        bool UpdateUser(UserModel userData);
    }
}
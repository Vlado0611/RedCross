using RedCross.Repository.DBOperations;
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Implementations 
{
    public class MemberService : IMemberService
    {

        public List<MemberModel> GetMembers()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return MemberOperations.GetMembers(connectionString);
        }

        public MemberModel GetMemberByID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return MemberOperations.GetMemberByID(id, connectionString);
        }
    }


}
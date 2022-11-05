using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Interfaces
{
    public interface IMemberService
    {
        List<MemberModel> GetMembers();

        MemberModel GetMemberByID(int id);
    }
}
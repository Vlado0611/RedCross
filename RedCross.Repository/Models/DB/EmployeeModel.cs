using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.Models.DB
{
    public class EmployeeModel : MemberModel
    {
        public int EmployeeID { get; set; }
        public String EmployeeName { get; set; }
        public String EmployeeSurname { get; set; }
        public string QualificationName { get; set; }
        public string PositionName { get; set; }


    }
}

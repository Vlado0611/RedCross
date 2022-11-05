using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.Models.DB
{
    public class MemberModel
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CUID { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string City { get; set; }
        public string FullName { get; set; }
    }
}

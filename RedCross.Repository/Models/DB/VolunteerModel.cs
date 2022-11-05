using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.Models.DB
{
    public class VolunteerModel : MemberModel
    {   
        public int VolunteerID { get; set; }
        public String VolunteerName { get; set; }
        public String VolunteerSurname { get; set; }
        public int? ActionNo { get; set; }
        public DateTime? LastAction { get; set; }
        public string Status { get; set; }
    }
}

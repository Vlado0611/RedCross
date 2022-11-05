using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.Models.DB
{
    public class ActionModel
    {
        public int ActionID { get; set; }
        public int BeneficiaryID { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiarySurname { get; set; }
        public int VolunteerID { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerSurname { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

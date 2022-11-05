using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCross.Repository.Models.DB
{
    public class BeneficiaryModel
    {
        public int BeneficiaryID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CUID { get; set; }
        public int Priority { get; set; }
        public string City { get; set; }
        public string FullName { get; set; }
    }
}

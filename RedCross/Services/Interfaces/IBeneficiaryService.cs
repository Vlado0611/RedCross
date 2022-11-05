using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Interfaces
{
    public interface IBeneficiaryService
    {
        List<BeneficiaryModel> GetBeneficiaries();
        BeneficiaryModel GetBeneficiaryByID(int id);
        bool DeleteBeneficiary(int beneficiaryID);
        bool InsertBeneficiary(BeneficiaryModel beneficiary);
        bool UpdateBeneficiary(BeneficiaryModel beneficiary);
    }
}
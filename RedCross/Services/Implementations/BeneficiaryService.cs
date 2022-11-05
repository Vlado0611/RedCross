using RedCross.Repository.DBOperations;
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Implementations
{
    public class BeneficiaryService : IBeneficiaryService
    {
        public bool DeleteBeneficiary(int beneficiaryID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;
            return BeneficiaryOperations.DeleteBeneficiary(beneficiaryID, connectionString);
        }

        public List<BeneficiaryModel> GetBeneficiaries()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;
            return BeneficiaryOperations.GetBeneficiaries(connectionString);
        }

        public BeneficiaryModel GetBeneficiaryByID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;
            return BeneficiaryOperations.GetBeneficiaryByID(id, connectionString);
        }

        public bool InsertBeneficiary(BeneficiaryModel beneficiary)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;
            return BeneficiaryOperations.InsertBeneficiary(beneficiary, connectionString);
        }

        public bool UpdateBeneficiary(BeneficiaryModel beneficiary)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;
            return BeneficiaryOperations.UpdateBeneficiary(beneficiary, connectionString);
        }
    }
}
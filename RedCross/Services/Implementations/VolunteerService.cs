using RedCross.Repository.DBOperations;
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Implementations
{
    public class VolunteerService : IVolunteerService
    {
        public VolunteerModel GetVolunteerByID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return VolunteerOperations.GetVolunteerByID(id, connectionString);
        }

        public List<VolunteerModel> GetVolunteers()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return VolunteerOperations.GetVolunteers(connectionString);
        }

        public List<VolunteerModel> GetVolunteersFullDetails()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return VolunteerOperations.GetVolunteersFullDetails(connectionString);
        }
        public bool DeleteVolunteer(int volunteerID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return VolunteerOperations.DeleteVolunteer(volunteerID, connectionString);
        }

        public VolunteerModel GetVolunteerFullDetailsByID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return VolunteerOperations.GetVolunteerFullDetailsByID(id, connectionString);
        }

        public bool InsertVolunteer(VolunteerModel volunteer)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return VolunteerOperations.InsertVolunteer(volunteer, connectionString);
        }

        public bool UpdateVolunteer(VolunteerModel volunteer)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return VolunteerOperations.UpdateVolunteer(volunteer, connectionString);
        }
    }
}
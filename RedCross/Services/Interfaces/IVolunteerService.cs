using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Interfaces
{
    public interface IVolunteerService
    {
        List<VolunteerModel> GetVolunteers();
        VolunteerModel GetVolunteerByID(int id);
        List<VolunteerModel> GetVolunteersFullDetails();
        VolunteerModel GetVolunteerFullDetailsByID(int id);
        bool DeleteVolunteer(int volunteerID);
        bool InsertVolunteer(VolunteerModel volunteer);
        bool UpdateVolunteer(VolunteerModel volunteer);
    }
}
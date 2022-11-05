using RedCross.Repository.DBOperations;
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Implementations
{
    public class StatusService : IStatusService
    {
        public List<StatusModel> GetStatuses()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return StatusOperations.GetStatuses(connectionString);
        }
    }
}
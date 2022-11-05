using RedCross.Repository.DBOperations;
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Implementations
{
    public class ActionService : IActionService
    {
        public List<ActionModel> GetActions()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.GetActions(connectionString);
        }

        public List<ActionModel> GetActionsByBeneficiaryID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.GetActionsByBeneficiaryID(id, connectionString);
        }

        public List<ActionModel> GetActionsByVolunteerID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.GetActionsByVolunteerID(id, connectionString);
        }

        public ActionModel GetActionByActionID(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.GetActionByActionID(id, connectionString);
        }

        public bool DeleteAction(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.DeleteAction(id, connectionString);
        }

        public bool InsertAction(ActionModel action)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.InsertAction(action, connectionString);
        }

        public bool UpdateAction(ActionModel action)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.UpdateAction(action, connectionString);
        }

        public List<ActionModel> GetActionsFullDetails()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RedCrossDB"].ConnectionString;

            return ActionOperations.GetActionsFullDetails(connectionString);
        }
    }
}
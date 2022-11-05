using RedCross.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Services.Interfaces
{
    public interface IActionService
    {
        List<ActionModel> GetActions();
        List<ActionModel> GetActionsByBeneficiaryID(int id);
        List<ActionModel> GetActionsByVolunteerID(int id);
        ActionModel GetActionByActionID(int id);
        List<ActionModel> GetActionsFullDetails();
        bool DeleteAction(int id);
        bool InsertAction(ActionModel action);
        bool UpdateAction(ActionModel action);
    }
}
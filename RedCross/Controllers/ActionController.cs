using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCross.Controllers
{
    public class ActionController : Controller
    {

        private IActionService _actionService;
        private IBeneficiaryService _beneficiaryService;
        private IVolunteerService _volunteerService;

        public ActionController(IActionService actionService, IBeneficiaryService beneficiaryService, IVolunteerService volunteerService)
        {
            this._actionService = actionService;
            this._beneficiaryService = beneficiaryService;
            this._volunteerService = volunteerService;
        }
        // GET: Action
        public ActionResult Index()
        {
            List<ActionModel> actions = this._actionService.GetActionsFullDetails();
            ViewBag.Actions = actions;
            return View();
        }
        
        public ActionResult ViewActionDetails(int id)
        {
            ActionModel action = this._actionService.GetActionByActionID(id);
            return View(action);
        }

        public ActionResult DeleteAction(int id)
        {
            bool result = this._actionService.DeleteAction(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            List<BeneficiaryModel> beneficiaries = this._beneficiaryService.GetBeneficiaries();
            foreach(BeneficiaryModel beneficiary in beneficiaries)
            {
                beneficiary.FullName = string.Format("{0} {1}", beneficiary.Name, beneficiary.Surname);
            }
            ViewBag.Beneficiaries = beneficiaries;

            List<VolunteerModel> volunteers = this._volunteerService.GetVolunteersFullDetails();
            foreach (VolunteerModel volunteer in volunteers)
            {
                volunteer.FullName = string.Format("{0} {1}", volunteer.Name, volunteer.Surname);
            }
            ViewBag.Volunteers = volunteers;

            ViewBag.Heading = "Insert An Action";

            return View("Action");
        }

        public ActionResult Store(ActionModel actionm)
        {
            bool result = false;
            ActionModel action = actionm;
            if(action.ActionID == 0)
            {
                result = this._actionService.InsertAction(action);
            }
            else
            {
                result = this._actionService.UpdateAction(action);
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<BeneficiaryModel> beneficiaries = this._beneficiaryService.GetBeneficiaries();
                foreach (BeneficiaryModel beneficiary in beneficiaries)
                {
                    beneficiary.FullName = string.Format("{0} {1}", beneficiary.Name, beneficiary.Surname);
                }
                ViewBag.Beneficiaries = beneficiaries;

                List<VolunteerModel> volunteers = this._volunteerService.GetVolunteersFullDetails();
                foreach (VolunteerModel volunteer in volunteers)
                {
                    volunteer.FullName = string.Format("{0} {1}", volunteer.Name, volunteer.Surname);
                }
                ViewBag.Volunteers = volunteers;

                return View("Action", action);
            }
        }

        public ActionResult Edit(int actionID)
        {
            ActionModel action = this._actionService.GetActionByActionID(actionID);

            List<BeneficiaryModel> beneficiaries = this._beneficiaryService.GetBeneficiaries();
            foreach (BeneficiaryModel beneficiary in beneficiaries)
            {
                beneficiary.FullName = string.Format("{0} {1}", beneficiary.Name, beneficiary.Surname);
            }
            ViewBag.Beneficiaries = beneficiaries;

            List<VolunteerModel> volunteers = this._volunteerService.GetVolunteersFullDetails();
            foreach (VolunteerModel volunteer in volunteers)
            {
                volunteer.FullName = string.Format("{0} {1}", volunteer.Name, volunteer.Surname);
            }
            ViewBag.Volunteers = volunteers;

            ViewBag.Heading = "Update An Action";

            return View("Action", action);
        }
    }
}
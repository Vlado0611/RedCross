using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCross.Controllers
{
    public class ReportsController : Controller
    {
        IActionService _actionService;
        IVolunteerService _volunteerService;
        IBeneficiaryService _beneficiaryService;
        IEmployeeService _employeeService;

        public ReportsController(IActionService actionService, IVolunteerService volunteerService, IBeneficiaryService beneficiaryService, IEmployeeService employeeService)
        {
            this._actionService = actionService;
            this._volunteerService = volunteerService;
            this._beneficiaryService = beneficiaryService;
            this._employeeService = employeeService;
        }

        public ActionResult Index()
        {
            List<ActionModel> actions = this._actionService.GetActionsFullDetails();
            ViewBag.Actions = actions;

            List<VolunteerModel> volunteers = this._volunteerService.GetVolunteersFullDetails();
            ViewBag.Volunteers = volunteers;

            List<BeneficiaryModel> beneficiaries = this._beneficiaryService.GetBeneficiaries();
            ViewBag.Beneficiaries = beneficiaries;

            List<EmployeeModel> employees = this._employeeService.GetEmployeesFullDetails();
            ViewBag.Employees = employees;
            
            return View();
        }
    }
}
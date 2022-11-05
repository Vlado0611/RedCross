using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCross.Controllers
{
    public class BeneficiaryController : Controller
    {
        IBeneficiaryService _beneficiaryService;
        ICityService _cityService;
        IActionService _actionService;

        public BeneficiaryController(IBeneficiaryService beneficiaryService, ICityService cityService, IActionService actionService)
        {
            this._beneficiaryService = beneficiaryService;
            this._cityService = cityService;
            this._actionService = actionService;
        }
        // GET: Beneficiary
        public ActionResult Index()
        {
            List<BeneficiaryModel> beneficiaries = this._beneficiaryService.GetBeneficiaries();
            ViewBag.Beneficiaries = beneficiaries;
            return View();
        }

        public ActionResult ViewBeneficiaryDetails(int id)
        {
            BeneficiaryModel beneficiary = this._beneficiaryService.GetBeneficiaryByID(id);

            List<ActionModel> actions = this._actionService.GetActionsByBeneficiaryID(id);
            ViewBag.Actions = actions;

            return View(beneficiary);
        }

        public ActionResult DeleteBeneficiary(int id)
        {
            bool result = this._beneficiaryService.DeleteBeneficiary(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            List<CityModel> cities = this._cityService.GetCities();
            ViewBag.Cities = cities;

            ViewBag.Heading = "Insert A New Beneficiary";

            return View("Beneficiary");
        }

        public ActionResult Store(BeneficiaryModel beneficiary)
        {
            bool result = false;
            if(beneficiary.BeneficiaryID == 0)
            {
                result = this._beneficiaryService.InsertBeneficiary(beneficiary);
            }
            else
            {
                result = this._beneficiaryService.UpdateBeneficiary(beneficiary);
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<CityModel> cities = this._cityService.GetCities();
                ViewBag.Cities = cities;

                return View("Beneficiary", beneficiary);
            }
        }

        public ActionResult Edit(int beneficiaryID)
        {
            BeneficiaryModel beneficiary = this._beneficiaryService.GetBeneficiaryByID(beneficiaryID);

            List<CityModel> cities = this._cityService.GetCities();
            ViewBag.Cities = cities;

            ViewBag.Heading = "Update A Beneficiary";

            return View("Beneficiary", beneficiary);
        }
    }
}
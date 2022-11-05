using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCross.Controllers
{
    public class VolunteerController : Controller
    {
        private IVolunteerService _volunteerService;
        private ICityService _cityService;
        private IStatusService _statusService;
        private IActionService _actionService;

        public VolunteerController(IVolunteerService volunteerService, ICityService cityService, IStatusService statusService, IActionService actionService)
        {
            this._volunteerService = volunteerService;
            this._cityService = cityService;
            this._statusService = statusService;
            this._actionService = actionService;
        }
        // GET: Volunteer
        public ActionResult Index()
        {
            List<VolunteerModel> volunteers = this._volunteerService.GetVolunteersFullDetails();
            ViewBag.Volunteers = volunteers;
            return View();
        }

        public ActionResult ViewVolunteerDetails(int id)
        {
            VolunteerModel volunteer = this._volunteerService.GetVolunteerByID(id);

            List<ActionModel> actions = this._actionService.GetActionsByVolunteerID(id);
            ViewBag.Actions = actions;
            return View(volunteer);
        }

        public ActionResult DeleteVolunteer(int id)
        {
            bool result = this._volunteerService.DeleteVolunteer(id);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            List<CityModel> cities = this._cityService.GetCities();
            ViewBag.Cities = cities;

            List<StatusModel> statuses = this._statusService.GetStatuses();
            ViewBag.Statuses = statuses;

            ViewBag.Heading = "Insert A New Volunteer";

            return View("Volunteer");
        }

        public ActionResult Store(VolunteerModel volunteer)
        {
            bool result = false;
            if (volunteer.VolunteerID == 0)
            {
                result = this._volunteerService.InsertVolunteer(volunteer);
            }
            else
            {
                result = this._volunteerService.UpdateVolunteer(volunteer);
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<CityModel> cities = this._cityService.GetCities();
                ViewBag.Cities = cities;

                List<StatusModel> statuses = this._statusService.GetStatuses();
                ViewBag.Statuses = statuses;


                return View("Volunteer", volunteer);
            }
        }

        public ActionResult Edit(int volunteerID)
        {
            VolunteerModel volunteer = this._volunteerService.GetVolunteerFullDetailsByID(volunteerID);

            List<CityModel> cities = this._cityService.GetCities();
            ViewBag.Cities = cities;

            List<StatusModel> statuses = this._statusService.GetStatuses();
            ViewBag.Statuses = statuses;

            ViewBag.Heading = "Update A Volunteer";

            return View("Volunteer", volunteer);
        }
    }
}
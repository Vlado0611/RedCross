using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCross.Controllers
{   
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private IPositionService _positionService;
        private ICityService _cityService;
        private IQualificationService _qualificationService;
        public EmployeeController(IEmployeeService employeeService, IPositionService positionService, ICityService cityService, IQualificationService qualificationService)
        {
            this._employeeService = employeeService;
            this._positionService = positionService;
            this._cityService = cityService;
            this._qualificationService = qualificationService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeModel> employees = this._employeeService.GetEmployeesFullDetails();
            ViewBag.Employees = employees;
            return View();
        }

        public ActionResult ViewEmployeeDetails(int id)
        {
            EmployeeModel employee = this._employeeService.GetEmployeeByID(id);
            return View(employee);
        }

        public ActionResult DeleteEmployee(int id)
        {
            bool result = this._employeeService.DeleteEmployee(id);
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

            List<QualificationModel> quals = this._qualificationService.GetQualifications();
            ViewBag.Qualifications = quals;

            List<PositionModel> positions = this._positionService.GetPositions();
            ViewBag.Positions = positions;

            ViewBag.Heading = "Insert A New Employee";

            return View("Employee");
        }

        public ActionResult Store(EmployeeModel employee)
        {
            bool result = false;
            if (employee.EmployeeID == 0)
            {
                result = this._employeeService.InsertEmployee(employee);
            }
            else
            {
                result = this._employeeService.UpdateEmployee(employee);
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<CityModel> cities = this._cityService.GetCities();
                ViewBag.Cities = cities;

                List<QualificationModel> quals = this._qualificationService.GetQualifications();
                ViewBag.Qualifications = quals;

                List<PositionModel> positions = this._positionService.GetPositions();
                ViewBag.Positions = positions;

                return View("Employee", employee);
            }
        }

        public ActionResult Edit(int employeeID)
        {
            EmployeeModel employee = this._employeeService.GetEmployeeFullDetailsByID(employeeID);

            List<CityModel> cities = this._cityService.GetCities();
            ViewBag.Cities = cities;

            List<QualificationModel> quals = this._qualificationService.GetQualifications();
            ViewBag.Qualifications = quals;

            List<PositionModel> positions = this._positionService.GetPositions();
            ViewBag.Positions = positions;

            ViewBag.Heading = "Update An Employee";
            return View("Employee", employee);
        }
    }
}
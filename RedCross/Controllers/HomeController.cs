using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCross.Controllers
{
    
    public class HomeController : Controller
    {

        public IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            this._homeService = homeService;
        }
        // GET: Home
        public ActionResult Index()
        {
            HomeModel model = this._homeService.GetHomeModel(); 
            return View(model);
        }

        public ActionResult Contact()
        {
            return View("CustomView");
        }

        
    }
}
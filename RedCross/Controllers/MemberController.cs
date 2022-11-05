using RedCross.Repository.Models.DB;
using RedCross.Services.Implementations;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCross.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            this._memberService = memberService;
        }
        // GET: member
        public ActionResult Index()
        { 
            List<MemberModel> members = this._memberService.GetMembers();
            ViewBag.Members = members;
            return View();
        }

        public ActionResult ViewMemberDetails(int id)
        {
            MemberModel result = this._memberService.GetMemberByID(id);
            return View(result);
        }
    }
}
using RedCross.Repository.Models.DB;
using RedCross.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedCross.Controllers.api
{
    public class UserController : ApiController
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("api/user/login")]

        public IHttpActionResult Login([FromBody]UserModel userData)
        {
            UserModel result = this._userService.Login(userData);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/user/register")]

        public IHttpActionResult Register([FromBody]UserModel userData)
        {
            bool result = this._userService.InsertUser(userData);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/user/edit")]
        public IHttpActionResult Edit([FromBody]UserModel userData)
        {
            bool result = this._userService.UpdateUser(userData);
            return Ok(result);
        }
    }
}

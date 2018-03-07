using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace api_postman.Controllers
{
    public class DataController : ApiController
    {
        //For Anonymous users
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]

        public IHttpActionResult Get()
        {

            return Ok("Now server time is:" + DateTime.Now.ToString());
        }
        //For Authorized users
        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetAuthenticate()
        {

            var identity = (ClaimsIdentity)User.Identity;
          
            return Ok("Hello " + identity.Name);






        }

        //For Admin
        [Authorize(Roles="admin")]
        [HttpGet]
        [Route("api/data/authorize")]

        public IHttpActionResult GetAdmin()
        {

            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok("Hello "+ identity.Name + "Role: " + string.Join("", roles.ToList()));

        }

    }
}

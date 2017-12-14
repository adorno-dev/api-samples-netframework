using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.Samples.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        [Authorize(Roles = "User")]
        public string Get() => User.Identity.Name;
    }
}
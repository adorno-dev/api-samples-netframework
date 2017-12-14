using Api.Samples.Domain.Models;
using Api.Samples.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Api.Samples.WebApi.Controllers
{
    [AllowAnonymous]
    public class TodoController : ApiController
    {
        private TodoService service;

        public TodoController() => service = new TodoService();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage All()
            => Request.CreateResponse<IList<Todo>>(HttpStatusCode.OK, service.All());
    }
}
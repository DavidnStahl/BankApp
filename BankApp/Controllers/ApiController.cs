using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Authentication;
using BankApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    
    [BasicAuthenticationAttribute]
    public class ApiController : Controller
    {
        private readonly ICustomerService _service;

        public ApiController(ICustomerService customerService)
        {
            _service = customerService;
        }
        // GET: api/<controller>
        [HttpGet]
        [Route("api/me")]
        public JsonResult Get()
        {          
            var data = _service.GetAuthenticatedUser(Request);
            return Json(data);
        }
        // GET api/<controller>/5
        [Route("api/account/{id}")]
        [HttpGet]
        public JsonResult Get(int id, int offset,int limit)
        {
            var data = _service.GetTransactions(Request,id, offset, limit);
            return Json(data);
        }

    }
}

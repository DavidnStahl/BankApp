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
    
    [BasicAuthentication]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICustomerService _service;

        public ApiController(ICustomerService customerService)
        {
            _service = customerService;
        }


        [HttpGet]
        [Route("api/me")]
        public IActionResult Get()
        {          
            var data = _service.GetAuthenticatedUser(Request);
            return Ok(data);
        }

        [Route("api/account/{id}")]
        [HttpGet]
        public IActionResult Get(int id, int offset,int limit)
        {
            var data = _service.GetTransactions(Request,id, offset, limit);
            if (data == null) return NotFound();
            return Ok(data);
        }

    }
}

using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.OldFashion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarket.WebApp.Api.Controllers
{
    [Route("api/ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly ICustomerService _customerService; // Old fashion

		public PingController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
        [Route("index")]
        public async Task<ActionResult<CustomerContract>> Index()
        {
            var result = await _customerService.GetCustomer("ERNSH");
            
            return Ok(result);
        }
    }

}

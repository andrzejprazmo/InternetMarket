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
        private readonly IPersonService _personService; // Old fashion

		public PingController(IPersonService personService)
		{
			_personService = personService;
		}

		[HttpGet]
        [Route("index")]
        public ActionResult<string> Index()
        {
            string result = _personService.Foo();
            
            return Ok(result);
        }
    }

}

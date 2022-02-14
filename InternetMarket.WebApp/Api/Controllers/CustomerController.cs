using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarket.WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-customer/{customerId}")]
        public async Task<ActionResult<CustomerContract>> GetCustomerById(string customerId)
        {
            return await _mediator.Send(new GetCustomerByIdRequest(customerId));
        }
    }
}

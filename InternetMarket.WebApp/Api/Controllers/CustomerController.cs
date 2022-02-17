using InternetMarket.Core.Commands.CreateCustomer;
using InternetMarket.Core.Common;
using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Queries.GetCustomer;
using InternetMarket.Core.Queries.GetCustomerOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarket.WebApp.Api.Controllers
{
    [Route("api/customer")]
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
        public async Task<ActionResult<CustomerContract>> GetCustomer(string customerId)
        {
            var result = await _mediator.Send(new GetCustomerRequest(customerId));
            return result;
        }

        [HttpGet]
        [Route("get-orders/{customerId}")]
        public async Task<ActionResult<CustomerOrdersContract>> GetCustomerOrders(string customerId)
        {
            return await _mediator.Send(new GetCustomerOrdersRequest(customerId));
        }

        [HttpPost]
        [Route("create-customer")]
        public async Task<ActionResult<CommandResult<string>>> CreateCustomer(CreateCustomerRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}

using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Queries.GetCustomerByOrder;
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
	public class OrderController : ControllerBase
	{
		private readonly IMediator _mediator;
		public OrderController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("get-customer/{orderId}")]
		public async Task<ActionResult<CustomerContract>> GetCustomer(int orderId)
		{
			return await _mediator.Send(new GetCustomerByOrderRequest(orderId));
		}

	}
}

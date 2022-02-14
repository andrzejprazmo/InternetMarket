using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using InternetMarket.Core.Queries.GetPersonById;

namespace InternetMarket.WebApp.Api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-person/{personId}")]
        public async Task<ActionResult<GetPersonByIdResponse>> GetPersonById(int personId)
        {
            return await _mediator.Send(new GetPersonByIdRequest(personId));
        }
    }
}

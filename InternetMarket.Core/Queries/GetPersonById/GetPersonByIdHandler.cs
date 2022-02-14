using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InternetMarket.Core.Common.Interfaces;

namespace InternetMarket.Core.Queries.GetPersonById
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdRequest, GetPersonByIdResponse>
    {
        private readonly IPersonRepository _personRepository;
        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<GetPersonByIdResponse> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetPersonById(request.PersonId);

            return new GetPersonByIdResponse
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Title = person.Title,
            };
        }
    }
}

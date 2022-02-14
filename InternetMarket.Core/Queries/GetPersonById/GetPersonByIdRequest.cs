using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetPersonById
{
    public class GetPersonByIdRequest : IRequest<GetPersonByIdResponse>
    {
        public int PersonId { get; set; }
        public GetPersonByIdRequest(int personId)
        {
            PersonId = personId;
        }
    }
}

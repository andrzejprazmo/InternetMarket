using InternetMarket.Core.Common;
using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternetMarket.Core.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CommandResult<string>>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CommandResult<string>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await Validate(request);
            if (validationResult.Failed)
            {
                return validationResult;
            }
            string customerId = await _customerRepository.CreateCustomer(new Domain.Entities.Customer 
            {
                Id = request.Id,
                Address = request.Address,
                City = request.City,
                CompanyName = request.CompanyName,
                ContactName = request.ContactName,
                ContactTitle = request.ContactTitle,
                Country = request.Country,
                Fax = request.Fax,
                Phone = request.Phone,
                PostalCode = request.PostalCode
            });
            return new CommandResult<string>
            {
                Value = customerId,
            };
        }

        private async Task<CommandResult<string>> Validate(CreateCustomerRequest request)
        {
            var commandResult = new CommandResult<string>();
            var customer = await _customerRepository.GetCustomerById(request.Id);
            if (customer != null)
            {
                commandResult.AddError(ErrorCodes.CustomerWithThisIdExists);
            }
            return commandResult;
        }
    }
}

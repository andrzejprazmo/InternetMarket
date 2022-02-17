using InternetMarket.Core.Common;
using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CreateCustomerHandler> _logger;
        public CreateCustomerHandler(ICustomerRepository customerRepository, ILogger<CreateCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<CommandResult<string>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogError(e, "System error", request);
                return new CommandResult<string>(e);
            }
        }

        private async Task<CommandResult<string>> Validate(CreateCustomerRequest request)
        {
            var commandResult = new CommandResult<string>();
            bool customerExists = await _customerRepository.IsCustomerExists(request.Id);
            if (customerExists)
            {
                commandResult.AddError(ErrorCodes.CustomerWithThisIdExists);
            }
            return commandResult;
        }
    }
}

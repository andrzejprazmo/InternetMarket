using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Common
{
    public static class ErrorCodes
    {
        public static CommandError CustomerWithThisIdExists = new CommandError(100, "Customer with this id exists");
        public static CommandError CustomerCompanyNameRequired = new CommandError(101, "Company name is required");
    }
}

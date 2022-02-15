using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Common.Contracts
{
    public class CustomerOrdersContract : CustomerContract
    {
        public IEnumerable<OrderContract> Orders { get; set; }
    }
}

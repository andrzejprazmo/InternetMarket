using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Common.Contracts
{
    public class OrderContract
    {
        public int Id { get; set; }
        public CustomerContract Customer { get; set; }
        public EmployeeContract Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
    }
}

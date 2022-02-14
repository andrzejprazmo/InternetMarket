using InternetMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Common.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonById(int personId);
    }
}

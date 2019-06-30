using Business.Entities;
using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IAccountRepository
    {
       List<Customer> GetCustomers();
    }
}

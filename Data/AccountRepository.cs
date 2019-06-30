using System.Collections.Generic;
using Business.Entities;
using Data.Contracts;

namespace Data
{
    public class AccountRepository : IAccountRepository
    {
        //Data is mocked in unit test project
        public List<Customer> GetCustomers()
        {
            return new List<Customer>();
        }
    }
}

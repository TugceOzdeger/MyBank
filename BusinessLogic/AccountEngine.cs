using Business.Entities;
using BusinessLogic.Contracts;
using Data.Contracts;
using System.Linq;
using System;

namespace BusinessLogic
{
    public class AccountEngine : IAccountEngine
    {
        private IAccountRepository IAccountRepository;
        public Customer Customer = new Customer();

        public AccountEngine(IAccountRepository _iAccountRepository)
        {
            IAccountRepository = _iAccountRepository;
        }

        public void OpenNewAccount(Guid CustomerId, decimal InitialCredit)
        {
            GetCustomer(CustomerId);
            Customer.Accounts.Add(new Account
            {
                Id = Guid.NewGuid(),
                Balance = InitialCredit
            });
        }

        private void GetCustomer(Guid CustomerId)
        {
            Customer = IAccountRepository.GetCustomers().FirstOrDefault(x => x.Id == CustomerId);
        }

        public string ShowUserInfo(Guid CustomerId)
        {
            GetCustomer(CustomerId);
            var text = "Name: " + Customer.Name + " Surname: " + Customer.Surname +
                       "Balance: " + Customer.Accounts.Sum(x => x.Balance);
            var tranText = " Transactions: ";
            foreach (var account in Customer.Accounts)
            {
                foreach (var tran in account.Transactions)
                {
                    tranText += "/n" + tran.Id + " " + tran.Amount;
                }        
            }
            return text + tranText;
        }
    }
}

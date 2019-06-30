using BusinessLogic.Contracts;
using Data.Contracts;
using System;
using System.Linq;
using Business.Entities;

namespace BusinessLogic
{
    public class TransactionEngine : ITransactionEngine
    {
        private IAccountRepository IAccountRepository;
        public Customer Customer = new Customer();

        public TransactionEngine(IAccountRepository _iAccountRepository)
        {
            IAccountRepository = _iAccountRepository;
        }

        public void TransferMoney(Guid CustomerId, decimal Amount)
        {
            Customer = IAccountRepository.GetCustomers().FirstOrDefault(x => x.Id == CustomerId);
            var lastAccount = Customer.Accounts.LastOrDefault();
            lastAccount.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                Amount = Amount
            });
            lastAccount.Balance += Amount;
        }
    }
}

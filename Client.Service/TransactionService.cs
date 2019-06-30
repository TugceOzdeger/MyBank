using System;
using Business.Contracts;
using Client.Contracts;

namespace Client.Service
{
    public class TransactionService : IClientTransactionService
    {
        private IBusinessTransactionService IBusinessTransactionService;

        TransactionService(IBusinessTransactionService iBusinessTransactionService)
        {
            IBusinessTransactionService = iBusinessTransactionService;
        }

        public void TransferMoney(Guid CustomerId, decimal Amount) => 
            IBusinessTransactionService.TransferMoney(CustomerId, Amount);
    }
}

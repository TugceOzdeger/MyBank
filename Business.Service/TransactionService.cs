using Business.Contracts;
using System;
using BusinessLogic.Contracts;
using System.ServiceModel;

namespace Business.Service
{
    public class TransactionService : IBusinessTransactionService
    {
        private ITransactionEngine ITransactionEngine;

        TransactionService(ITransactionEngine iTransactionEngine)
        {
            ITransactionEngine = iTransactionEngine;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void TransferMoney(Guid CustomerId, decimal Amount) => ITransactionEngine.TransferMoney(CustomerId, Amount);
    }
}

using System;
using Data.Contracts;

namespace Data
{
    public class TransactionRepository : ITransactionRepository
    {
        //Data is mocked in unit test project
        public void TransferMoney(Guid CustomerId, Guid AccountId, decimal Amount){}
    }
}

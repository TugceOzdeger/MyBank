using System;

namespace Data.Contracts
{
    public interface ITransactionRepository
    {
        void TransferMoney(Guid CustomerId, Guid AccountId, decimal Amount);
    }
}

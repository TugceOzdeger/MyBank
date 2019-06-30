using Business.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Contracts
{
    public interface ITransactionEngine
    {
        void TransferMoney(Guid CustomerId, decimal Amount);
    }
}

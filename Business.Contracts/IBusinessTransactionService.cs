using System;
using System.ServiceModel;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusinessTransactionService
    {
        [OperationContract]
        void TransferMoney(Guid CustomerId, decimal Amount);
    }
}

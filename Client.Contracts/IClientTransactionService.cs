using System;
using System.ServiceModel;

namespace Client.Contracts
{
    [ServiceContract]
    public interface IClientTransactionService
    {
        [OperationContract]
        void TransferMoney(Guid CustomerId, decimal Amount);
    }
}

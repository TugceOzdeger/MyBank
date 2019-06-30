using System;
using System.ServiceModel;

namespace Client.Contracts
{
    [ServiceContract]
    public interface IClientAccountService
    {
        [OperationContract]
        void OpenNewAccount(Guid CustomerId, decimal InitialCredit);

        [OperationContract]
        string ShowUserInfo(Guid CustomerId);
    }
}

using System;
using System.ServiceModel;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusinessAccountService
    {
        [OperationContract]
        void OpenNewAccount(Guid CustomerId, decimal InitialCredit);

        [OperationContract]
        string ShowUserInfo(Guid CustomerId);
    }
}

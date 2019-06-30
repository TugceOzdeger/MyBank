using Business.Contracts;
using BusinessLogic.Contracts;
using System;
using System.ServiceModel;

namespace Business.Service
{
    public class AccountService : IBusinessAccountService
    {
        private IAccountEngine IAccountEngine;

        AccountService(IAccountEngine iAccountEngine)
        {
            IAccountEngine = iAccountEngine;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void OpenNewAccount(Guid CustomerId, decimal InitialCredit) => 
                        IAccountEngine.OpenNewAccount(CustomerId, InitialCredit);

        [OperationBehavior(TransactionScopeRequired = true)]
        public string ShowUserInfo(Guid CustomerId) => IAccountEngine.ShowUserInfo(CustomerId);
    }
}

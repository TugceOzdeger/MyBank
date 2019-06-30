using Business.Contracts;
using Client.Contracts;
using System;

namespace Client.Service
{
    public class AccountService : IClientAccountService
    {
        private IBusinessAccountService IBusinessAccountService;

        AccountService(IBusinessAccountService iBusinessAccountService)
        {
            IBusinessAccountService = iBusinessAccountService;
        }

        public void OpenNewAccount(Guid CustomerId, decimal InitialCredit) => 
                            IBusinessAccountService.OpenNewAccount(CustomerId, InitialCredit);

        public string ShowUserInfo(Guid CustomerId) => 
                            IBusinessAccountService.ShowUserInfo(CustomerId);
    }
}

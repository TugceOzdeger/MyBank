using System;

namespace BusinessLogic.Contracts
{
    public interface IAccountEngine
    {
        void OpenNewAccount(Guid CustomerId, decimal InitialCredit);
        string ShowUserInfo(Guid CustomerId);
    }
}

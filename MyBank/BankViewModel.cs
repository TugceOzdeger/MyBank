using Client.Contracts;
using System;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;

namespace MyBank
{
    public class BankViewModel
    {
        private IClientAccountService AccountService;
        private IClientTransactionService TransactionService;
        private Guid _customerId { get; set; }
        private decimal _initialCredit { get; set; }
        private string _userInfo { get; set; }

        //DI needs more work since it calls default constructor so that's why UI does not work
        public BankViewModel()
        {

        }

        [PreferredConstructor]
        public BankViewModel(IClientAccountService accountService, IClientTransactionService transactionService)
        {                     
            AccountService = accountService;
            TransactionService = transactionService;
        }

        #region Commands
        public RelayCommand OpenAccountCommand => new RelayCommand(OpenNewAccount);

        #endregion

        #region Properties

        public Guid CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public decimal InitialCredit
        {
            get { return _initialCredit; }
            set { _initialCredit = value; }
        }

        public string UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        #endregion

        #region Private Functions  
        private void OpenNewAccount()
        {
            if (AccountService == null) return;
            AccountService.OpenNewAccount(CustomerId, InitialCredit);
            if (InitialCredit > 0)
                TransactionService.TransferMoney(CustomerId, InitialCredit);
            UserInfo = AccountService.ShowUserInfo(CustomerId);
        }
        #endregion        
    }
}

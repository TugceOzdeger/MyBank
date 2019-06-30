using Business.Entities;
using Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BusinessLogicTests
    {
        private Mock<IAccountRepository> mockAcc;
        private Guid customerId1 = new Guid("00000000-0000-0000-0000-000000000001");
        private Guid customerId2 = new Guid("00000000-0000-0000-0000-000000000002");

        [TestInitialize]
        public void SetUp()
        {
            mockAcc = new Mock<IAccountRepository>();
            mockAcc.Setup(m => m.GetCustomers())
                   .Returns(GetCustomers())
                   .Verifiable();
        }

        //Test Data
        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = customerId1,
                    Name = "Tugce",
                    Surname = "Ozdeger",
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            Id = Guid.NewGuid(),
                            Balance = new decimal(10000),
                            CustomerId = customerId1,
                            Transactions = new List<Transaction>
                            {
                                new Transaction
                                {
                                    Id = Guid.NewGuid(),
                                    Amount = 5000M
                                },
                                new Transaction
                                {
                                    Id = Guid.NewGuid(),
                                    Amount = 5000M
                                }
                            }
                        }
                    }
                },
                new Customer
                {
                    Id = customerId2,
                    Name = "Russell",
                    Surname = "Brown",
                    Accounts = new List<Account>
                    {                      
                        new Account
                        {
                            Id = Guid.NewGuid(),
                            Balance = new decimal(20000),
                            CustomerId = customerId2,
                            Transactions = new List<Transaction>
                            {
                                new Transaction
                                {
                                    Id = Guid.NewGuid(),
                                    Amount = 10000M
                                },
                                new Transaction
                                {
                                    Id = Guid.NewGuid(),
                                    Amount = 10000M
                                }
                            }
                        },
                        new Account
                        {
                            Id = Guid.NewGuid(),
                            Balance = new decimal(15000),
                            CustomerId = customerId2,
                            Transactions = new List<Transaction>
                            {                                
                                new Transaction
                                {
                                    Id = Guid.NewGuid(),
                                    Amount = 15000M
                                }
                            }
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void Test_Open_New_Account_Tugce()
        {
            var sut = new AccountEngine(mockAcc.Object);
            sut.OpenNewAccount(customerId1, 1000M);
            Assert.AreEqual(sut.Customer.Accounts.Count, 2);
        }

        [TestMethod]
        public void Test_Open_New_Account_Russell()
        {
            var sut = new AccountEngine(mockAcc.Object);
            sut.OpenNewAccount(customerId2, 1000M);
            Assert.AreEqual(sut.Customer.Accounts.Count, 3);
        }

        [TestMethod]
        public void Test_Transfer_Money_Tugce()
        {
            var sut = new TransactionEngine(mockAcc.Object);
            sut.TransferMoney(customerId1, 1000M);
            var lastAccount = sut.Customer.Accounts.LastOrDefault(x => x.CustomerId == customerId1);         
            Assert.AreEqual(lastAccount.Transactions.Count, 3);
            Assert.AreEqual(lastAccount.Balance,11000M);
        }

        [TestMethod]
        public void Test_Transfer_Money_Russell()
        {
            var sut = new TransactionEngine(mockAcc.Object);
            sut.TransferMoney(customerId2, 1000M);
            var lastAccount = sut.Customer.Accounts.LastOrDefault(x => x.CustomerId == customerId2);
            Assert.AreEqual(lastAccount.Transactions.Count, 2);
            Assert.AreEqual(lastAccount.Balance, 16000M);
        }

    }
}

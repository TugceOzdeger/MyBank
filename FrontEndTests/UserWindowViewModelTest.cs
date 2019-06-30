using System;
using System.Collections.Generic;
using Business.Entities;
using Client.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyBank;

namespace Frontend.Tests
{
    [TestClass]
    public class UserWindowViewModelTest
    {
        private Mock<IClientAccountService> mockAcc;
        private Mock<IClientTransactionService> mockTran;

        [TestInitialize]
        public void SetUp()
        {
            mockAcc = new Mock<IClientAccountService>();
            mockTran = new Mock<IClientTransactionService>();
            //mockAcc.Setup(m => m.GetCustomers())
            //       .Returns(GetCustomers())
            //       .Verifiable();
        }

        //Test Data
        //private List<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer
        //        {
        //            Id = customerId1,
        //            Name = "Tugce",
        //            Surname = "Ozdeger",
        //            Accounts = new List<Account>
        //            {
        //                new Account
        //                {
        //                    Id = Guid.NewGuid(),
        //                    Balance = new decimal(10000),
        //                    CustomerId = customerId1,
        //                    Transactions = new List<Transaction>
        //                    {
        //                        new Transaction
        //                        {
        //                            Id = Guid.NewGuid(),
        //                            Amount = 5000M
        //                        },
        //                        new Transaction
        //                        {
        //                            Id = Guid.NewGuid(),
        //                            Amount = 5000M
        //                        }
        //                    }
        //                }
        //            }
        //        },
        //        new Customer
        //        {
        //            Id = customerId2,
        //            Name = "Russell",
        //            Surname = "Brown",
        //            Accounts = new List<Account>
        //            {
        //                new Account
        //                {
        //                    Id = Guid.NewGuid(),
        //                    Balance = new decimal(20000),
        //                    CustomerId = customerId2,
        //                    Transactions = new List<Transaction>
        //                    {
        //                        new Transaction
        //                        {
        //                            Id = Guid.NewGuid(),
        //                            Amount = 10000M
        //                        },
        //                        new Transaction
        //                        {
        //                            Id = Guid.NewGuid(),
        //                            Amount = 10000M
        //                        }
        //                    }
        //                },
        //                new Account
        //                {
        //                    Id = Guid.NewGuid(),
        //                    Balance = new decimal(15000),
        //                    CustomerId = customerId2,
        //                    Transactions = new List<Transaction>
        //                    {
        //                        new Transaction
        //                        {
        //                            Id = Guid.NewGuid(),
        //                            Amount = 15000M
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    };
        //}

        [TestMethod]
        public void Test_If_Transaction_Made_When_Initial_Credit_Zero()
        {
            var sut = new UserWindowViewModel(mockAcc.Object, mockTran.Object)
            {
                CustomerId = Guid.NewGuid(),
                InitialCredit = 0
            };
            sut.OpenNewAccount();
            //Assert.AreEqual(sut.Transactions.Count, 3);
        }

        [TestMethod]
        public void Test_If_Transaction_Made_When_Initial_Credit_Not_Zero()
        {
            var sut = new UserWindowViewModel(mockAcc.Object, mockTran.Object)
            {
                CustomerId = Guid.NewGuid(),
                InitialCredit = 3000
            };
            sut.OpenNewAccount();
            //Assert.AreEqual(lastAccount.Transactions.Count, 3);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Client.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Guid CustomerId { get; set; }
    }
}

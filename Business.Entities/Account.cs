using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public decimal Balance { get; set; }

        [DataMember]
        public List<Transaction> Transactions { get; set; }

        [DataMember]
        public Guid CustomerId { get; set; }
    }
}

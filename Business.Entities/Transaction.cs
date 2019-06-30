using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Transaction
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public Guid AccountId { get; set; }
    }
}

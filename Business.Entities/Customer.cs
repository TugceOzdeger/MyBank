using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public List<Account> Accounts { get; set; }
    }
}

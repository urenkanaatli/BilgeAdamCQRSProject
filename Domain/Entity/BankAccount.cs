using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class BankAccount: IHaveDomainEvent
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public decimal Amount { get; set; }

        public string AccountName { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}

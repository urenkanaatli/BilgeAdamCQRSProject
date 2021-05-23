using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CreateBankAccountEvent: DomainEvent
    {
        public CreateBankAccountEvent(Domain.Entity.BankAccount bankAccount)
        {
            BankAccount = bankAccount;
        }

        Domain.Entity.BankAccount BankAccount { get; set; }
    }
}

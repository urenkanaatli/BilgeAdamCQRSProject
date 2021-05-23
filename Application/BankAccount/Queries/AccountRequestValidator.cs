using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BankAccount.Queries
{
    public class AccountRequestValidator : AbstractValidator<AccountRequest>
    {

        public AccountRequestValidator()
        {
            RuleFor(t => t.AccountId).GreaterThan(0).WithMessage("accountid 0 dan buyuk olamalı");
        }
    }
}

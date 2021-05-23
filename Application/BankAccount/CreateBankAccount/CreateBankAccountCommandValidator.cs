using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BankAccount.CreateBankAccount
{
    public class CreateBankAccountCommandValidator : AbstractValidator<CreateBankAccountCommand>
    {

        public CreateBankAccountCommandValidator()
        {
            RuleFor(t => t.AccountName).NotEmpty().WithMessage("Account adı boş olamaz").MinimumLength(5).WithMessage("Minimum 5 haneli olamlı");
            RuleFor(t => t.SeedAmount).GreaterThan(0).WithMessage("amount 0 dan buyuk olmalı").LessThan(5000).WithMessage("Amount max 5000 olmalı");

            RuleFor(t => t.UserId).NotEmpty().WithMessage("userid olmalı");


        }
    }
}

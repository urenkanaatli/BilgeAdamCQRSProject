using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Application.Common;
using Domain.Events;

//cqrs 
namespace Application.BankAccount.CreateBankAccount
{
    [Performance(Duration = 400)]
    [ApplicationAuthorize(Role = "Admin")]
    public class CreateBankAccountCommand : IRequest<int>
    {
        public string UserId { get; set; }

        public string AccountName { get; set; }

        public decimal SeedAmount { get; set; }
    }

    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, int>
    {
        private readonly IDbContext dbContext;

        public CreateBankAccountCommandHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {

            //Customer customer = new Customer();
            // CustomerValidator validator = new CustomerValidator();
            //ValidationResult result = validator.Validate(customer);

            //CreateBankAccountCommandValidator validationRules = new CreateBankAccountCommandValidator();

            //ValidationResult result = await validationRules.ValidateAsync(request);

            //if (!result.IsValid)
            //{
            //    throw new ValidationException("validation hatası", result.Errors);
            //}


            Domain.Entity.BankAccount account = new Domain.Entity.BankAccount
            {
                AccountName = request.AccountName,
                Amount = request.SeedAmount,
                UserId = request.UserId
            };

            account.DomainEvents.Add(new CreateBankAccountEvent(account));



            dbContext.bankAccounts.Add(account);





            return await dbContext.SaveAsync(cancellationToken);

        }
    }
}

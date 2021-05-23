using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Common;

namespace Application.BankAccount.Queries
{

    [Performance(Duration = 800)]
    public class AccountRequest : IRequest<Domain.Entity.BankAccount>
    {
        public int AccountId { get; set; }
    }


    public class AccountRequestHandler : IRequestHandler<AccountRequest, Domain.Entity.BankAccount>
    {

        private readonly IDbContext dbContext;

        public AccountRequestHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Domain.Entity.BankAccount> Handle(AccountRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.BankAccount account = await dbContext.bankAccounts.FindAsync(request.AccountId);

            return account;
        }
    }
}

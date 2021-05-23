using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BankAccount.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<int>
    {

        public int AccountId { get; set; }
    }



    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, int>
    {
        public async Task<int> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {



            return 1;
        }
    }
}

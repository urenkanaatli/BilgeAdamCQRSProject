using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BankAccount.EventHendlers
{
    public class CreatebankAccountEventHendler : INotificationHandler<CreateBankAccountEvent>
    {



        public async Task Handle(CreateBankAccountEvent notification, CancellationToken cancellationToken)
        {

            //ilgili accounta email atabilirim.

            int a = 20;


        }
    }
}

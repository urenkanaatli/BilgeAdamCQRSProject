using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDbContext
    {


        Task<int> SaveAsync(CancellationToken cancellationToken);

        DbSet<Domain.Entity.BankAccount> bankAccounts { get; set; }
    }
}

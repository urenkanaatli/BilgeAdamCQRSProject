using Application.Interfaces;
using Domain.Entity;
using Domain.Model;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        private readonly IDomainEventService domainEventService;

        public ApplicationDbContext(DbContextOptions options, IDomainEventService domainEventService) : base(options)
        {
            this.domainEventService = domainEventService;
        }

        public DbSet<BankAccount> bankAccounts { get; set; }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {

            var result = await this.SaveChangesAsync(cancellationToken);

            await fireEvents();

            return result;
        }

        private async Task fireEvents()
        {

            while (true)
            {

                DomainEvent domainEvent = ChangeTracker.Entries<IHaveDomainEvent>().Select(t => t.Entity.DomainEvents).SelectMany(a => a).Where(t => t.IsPublished == false).FirstOrDefault();

                if (domainEvent == null) break;


                domainEvent.IsPublished = true;
                await domainEventService.Publish(domainEvent);

            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }

    }
}

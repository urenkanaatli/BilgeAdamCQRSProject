using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Mappings
{
    public class BankAccountMapping : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            //fluent api
            builder.Property(t => t.AccountName).HasMaxLength(100);
            builder.Property(t => t.UserId).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Amount).HasPrecision(18, 2);
            builder.Ignore(t => t.DomainEvents);



        }
    }
}

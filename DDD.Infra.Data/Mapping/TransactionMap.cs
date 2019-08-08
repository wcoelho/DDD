using DDD.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mapping
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
	{
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Value)
                .IsRequired()
                .HasColumnName("Value");
            
            builder.Property(c => c.CheckingAccountId)
                .IsRequired()
                .HasColumnName("CheckingAccountId");

            builder.HasOne(c => c.CheckingAccount)
                .WithMany(c => c.Transactions)
                .IsRequired();
		}
        
    }
}
using DDD.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mapping
{
    public class CheckingAccountMap : IEntityTypeConfiguration<CheckingAccount>
	{
        public void Configure(EntityTypeBuilder<CheckingAccount> builder)
        {
            builder.ToTable("CheckingAccount");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Amount)
                .IsRequired()
                .HasColumnName("Amount");

            builder.Property(c => c.Limit)
                .IsRequired()
                .HasColumnName("Limit");
            
            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnName("IdUser");

            builder.HasOne(c => c.User)
                .WithMany(c => c.CheckingAccounts)
                .IsRequired();
		}
        
    }
}
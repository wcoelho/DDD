using DDD.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
	{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Cpf)
          .IsRequired()
          .HasColumnName("Cpf");

        builder.Property(c => c.BirthDate)
          .IsRequired()
          .HasColumnName("BirthDate");

        builder.Property(c => c.Name)
          .IsRequired()
          .HasColumnName("Name");

    }
	}
}
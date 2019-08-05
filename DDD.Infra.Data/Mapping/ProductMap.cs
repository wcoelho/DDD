using DDD.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
	{
        public void Configure(EntityTypeBuilder<Product> builder)
        {
        builder.ToTable("Product");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(c => c.Manufacturer)
            .IsRequired()
            .HasColumnName("Manufacturer");

        builder.Property(c => c.Code)
            .IsRequired()
            .HasColumnName("Code");
        
        builder.Property(c => c.Price)
            .IsRequired()
            .HasColumnName("Price");
        
        builder.Property(c => c.SKU)
            .IsRequired()
            .HasColumnName("SKU");
		}
        
    }
}
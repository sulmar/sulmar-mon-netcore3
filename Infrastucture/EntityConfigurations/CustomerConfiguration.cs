using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(p => p.Id)
                .HasColumnName("CustomerId");

            builder
                .Property(p => p.Pesel)
                .HasMaxLength(11)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

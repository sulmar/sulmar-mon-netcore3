using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .ToTable("Addressses");

            builder
                .Property(p => p.City)
                .HasMaxLength(40);

            builder
                .Property(p => p.Street)
                .HasMaxLength(40);

            builder
                .Property(p => p.Id)
                .HasColumnName("AddressId");
        }
    }
}
